
using IronBarCode;

namespace MAUI_Barcode;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void SelectBarcode(object sender, EventArgs e)
	{
		var images = await FilePicker.Default.PickAsync(new PickOptions
		{
			PickerTitle = "Pick image",
			FileTypes = FilePickerFileType.Images
		});
		var imageSource = images.FullPath.ToString();
		barcodeImage.Source = imageSource;
		var result = BarcodeReader.Read(imageSource).First().Text;
		outputText.Text = result;
		
    }
	private async void CopyEditorText (object sender, EventArgs e)
	{
        await Clipboard.SetTextAsync(outputText.Text);
        await DisplayAlert("Success", "Text is copied!", "OK");
    }
}

