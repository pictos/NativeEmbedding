namespace EmbeddingAndroid;
internal class MyMauiPage : ContentPage
{

	public MyMauiPage()
	{
		BindingContext = new MyMauiViewModel();
		var label = new Label
		{
			Text = "Hello from Maui!",
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			TextColor = Colors.Fuchsia
		};

		var button = new Button
		{
			Text = "Click Me!",
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};

		button.Clicked += (sender, e) =>
		{
			var binding = new Binding
			{
				Path = nameof(MyMauiViewModel.Name),
				Source = BindingContext
			};
			label.SetBinding(Label.TextProperty, binding);
		};

		Content = new VerticalStackLayout
		{
			Children =
			{
				label,
				button
			}
		};
	}
}


internal class MyMauiViewModel
{
	public string Name => "Hello from ViewModel!";
}
