using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

using static System.Math;

namespace Confetti
{

    public class ConfettiView : UIView
    {
        public UIColor[] Colors { get; set; }
        public float Intensity { get; set; }
        public ConfettiType ConfettiType { get; set; }
        public UIImage CustomImage { get; set; }
        private bool Active { get; set; }
        private CAEmitterLayer Emitter { get; set; }

        const float PI_4 = (float) PI / 4;
        const float PI_2 = (float) PI / 2;

        public ConfettiView(NSCoder coder): base(coder)
        {
            Setup();
        }

        public ConfettiView(CGRect frame) : base(frame)
        {
            Setup();
        }

        private void Setup()
        {

            Colors = new UIColor[] {
                UIColor.FromRGBA(242, 102, 69, 255),
                UIColor.FromRGBA(255, 199, 98, 255),
                UIColor.FromRGBA(122, 199, 163, 255),
                UIColor.FromRGBA(76, 198, 217, 255),
                UIColor.FromRGBA(142, 100, 140, 255)
            };

            Intensity = 0.5F;
            ConfettiType = ConfettiType.Confetti;
            Active = false;
        }

        public void StartConfetti()
        {
            Emitter = new CAEmitterLayer();

            Emitter.Position = new CGPoint(Frame.Size.Width / 2.0, 0);
            Emitter.Shape = "kCAEmitterLayerLine";
            Emitter.Size = new CGSize(Frame.Size.Width, 1);

            var cells = new CAEmitterCell[Colors.Length];
            for (var i = 0; i < Colors.Length; i++)
            {
                cells[i] = ConfettiWithColor(Colors[i]);
            }

            Emitter.Cells = cells;

            Layer.AddSublayer(Emitter);
            Active = true;
        }

        public void StopConfetti()
        {
            if (Emitter != null) Emitter.BirthRate = 0;
            Active = false;
        }

        public UIImage ImageForType(ConfettiType confettiType)
        {

            string fileName = "confetti";

            switch (ConfettiType)
            {
                case ConfettiType.Confetti:
                    fileName = "confetti";
                    break;
                case ConfettiType.Triangle:
                    fileName = "triangle";
                    break;
                case ConfettiType.Star:
                    fileName = "star";
                    break;
                case ConfettiType.Diamond:
                    fileName = "diamond";
                    break;
                case ConfettiType.Image:
                    return CustomImage;
            }

            return UIImage.FromBundle($"{fileName}.png");
        }

        private CAEmitterCell ConfettiWithColor(UIColor color)
        {
            var confetti = new CAEmitterCell
            {
                BirthRate = 6F * Intensity,
                LifeTime = 14F * Intensity,
                LifetimeRange = 0,
                Color = color.CGColor,
                Velocity = 350.0F * Intensity,
                VelocityRange = 80.0F * Intensity,
                EmissionLongitude = PI_2,
                EmissionRange = PI_4,
                Spin = 3.5F * Intensity,
                SpinRange = 4F * Intensity,
                ScaleRange = Intensity,
                ScaleSpeed = -0.1F * Intensity,
                Contents = ImageForType(ConfettiType)?.CGImage
            };
            return confetti;
        }
    }
}

