namespace EmbeddingAndroid;

public partial class MyMauiXamlPage : ContentPage
{
	public MyMauiXamlPage()
	{
		BindingContext = new MyMauiViewModel();
		InitializeComponent();
	}
}