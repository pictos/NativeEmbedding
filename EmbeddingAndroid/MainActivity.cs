using Android.App;
using Android.OS;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;

namespace EmbeddingAndroid;

[Activity(Label = "@string/app_name", MainLauncher = true,
	Theme = "@style/AppTheme")]
public class MainActivity : Activity
{
	MauiContext mauiContext = default!;
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		// Set our view from the "main" layout resource

		var view = HandleMauiBuilder().ToPlatform(mauiContext);

		SetContentView(view);
	}



	ContentPage HandleMauiBuilder()
	{
		var builder = MauiApp.CreateBuilder();

		var app = builder.UseMauiEmbedding<App>().Build();

		mauiContext = new(app.Services, this);

		return new MyMauiXamlPage();
	}
}


class App : Microsoft.Maui.Controls.Application
{

}