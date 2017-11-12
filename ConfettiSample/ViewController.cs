using System;
using Foundation;
using UIKit;


namespace Confetti
{
    public partial class ViewController : UIViewController
    {
        public ConfettiView ConfettiView { get; set; }
        private bool _isRainingConfetti;
            
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            // Create confetti view
            ConfettiView = new ConfettiView(View.Bounds);

            // Set intensity (from 0 - 1, default intensity is 0.5)
            ConfettiView.Intensity = 0.5f;

            // Set type
            ConfettiView.ConfettiType = ConfettiType.Star;

            // For custom image
            // confettiView.type = .Image(UIImage(named: "diamond")!)

            // Add subview
            View.AddSubview(ConfettiView);
        }


        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            if (_isRainingConfetti)
            {
                // Stop confetti
                ConfettiView.StopConfetti();
                //confettiStatus.text = "it's not raining confetti 🙁"
            }
            else {
                // Start confetti
                ConfettiView.StartConfetti();
                //confettiStatus.text = "it's raining confetti 🙂"
            }
            _isRainingConfetti = !_isRainingConfetti;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

