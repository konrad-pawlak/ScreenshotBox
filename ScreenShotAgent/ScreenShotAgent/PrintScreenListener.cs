
namespace ScreenshotBox
{
	class PrintScreenListener
	{
		public static void StartListening()
		{
			var image = System.Windows.Clipboard.GetImage();
			FileManager.SaveBitmap(image);
		}
	}
}
