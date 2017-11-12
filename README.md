# Xamarin.Ios.ConfettiView
Port of SAConfettiView to Xamarin.Ios

# SAConfettiView
It's raining confetti! SAConfettiView is the easiest way to add fun, multi-colored confetti to your application and make users feel rewarded. Written in csharp, SAConfettiView is a subclass of UIView and is highly customizable. From various types and colors of confetti to different levels of intensity, you can make the confetti as fancy as you want.

## Installation

Available from Nuget: [![NuGet][conf-link]]

[conf-link]:https://www.nuget.org/packages/Confetti/

## Usage

Creating a SAConfettiView is the same as creating a UIView:

```csharp
ConfettiView = new ConfettiView(View.Bounds);
```

Don't forget to add the subview!

```csharp
View.AddSubview(ConfettiView);
```

### Types

Pick one of the preconfigured types of confetti with the `type` property, or create your own by providing a custom image. This property defaults to the `Confetti` type.

##### `Confetti`

![confetti](https://cloud.githubusercontent.com/assets/11940172/11819440/c9db329e-a39a-11e5-9284-b0171bee0f24.gif)

```csharp
confettiView.type = ConfettiType.Confetti;
```

##### `.Triangle`

![triangle](https://cloud.githubusercontent.com/assets/11940172/11819211/9b8b758a-a399-11e5-8ed3-2eb92f633628.gif)

```csharp
confettiView.type = ConfettiType.Triangle;
```

##### `.Star`

![star](https://cloud.githubusercontent.com/assets/11940172/11819401/90a2188a-a39a-11e5-8a03-ddca3fb52e72.gif)

```csharp
confettiView.type = ConfettiType.Star;
```

##### `.Diamond`

![diamond](https://cloud.githubusercontent.com/assets/11940172/11819275/f1c83c08-a399-11e5-8d40-85e9a1879526.gif)

```csharp
confettiView.type = ConfettiType.Diamond;
```

##### `.Image`

![image](https://cloud.githubusercontent.com/assets/11940172/11819363/5f4f0dba-a39a-11e5-826b-d198113f50dd.gif)

### Intensity

The intensity refers to how many particles are generated and how quickly they fall. Set the intensity of the confetti with the `.intensity` property by passing in a value between 0 and 1. The default intensity is 0.5.

``` csharp
confettiView.Intensity = 0.75;
```

### Starting

To start the confetti, use

``` csharp
confettiView.StartConfetti();
```

### Stopping

To stop the confetti, use

``` csharp
confettiView.stopConfetti();
```

## License

MIT