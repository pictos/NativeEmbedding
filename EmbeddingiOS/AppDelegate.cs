using CoreGraphics;
using EmbeddingAndroid;
using Foundation;
using UIKit;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;

namespace EmbeddingiOS;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	MauiContext mauiContext = default!;
	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);


		var vc = new UIViewController ();
		var uiView = HandleMauiBuilder().ToPlatform(mauiContext);
		var size = vc.View!.Bounds.Size;
		uiView.Center = new CGPoint(size.Width / 2, size.Height / 2);
		vc.View!.Add(uiView);
		
		// vc.View!.AddSubview (new UILabel (Window!.Frame) {
		// 	BackgroundColor = UIColor.SystemBackground,
		// 	TextAlignment = UITextAlignment.Center,
		// 	Text = "Hello, iOS!",
		// 	AutoresizingMask = UIViewAutoresizing.All,
		// });
		
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
	
	
	ContentPage HandleMauiBuilder()
	{
		var builder = MauiApp.CreateBuilder();

		var app = builder.UseMauiEmbedding<App>().Build();

		mauiContext = new(app.Services);

		return new MyMauiPage();
	}
	
	class App : Microsoft.Maui.Controls.Application
	{

	}
}
