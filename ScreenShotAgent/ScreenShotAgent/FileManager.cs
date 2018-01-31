using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScreenshotBox
{
	public class FileManager
	{
		public static void SaveBitmap(BitmapSource image)
		{
			var stream = new FileStream(DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "new.png", FileMode.Create); 
			//TODO: Add counter to the screen name if the screenshots were taken at the same second
			var encoder = new PngBitmapEncoder();
			var myTextBlock = new TextBlock();
			myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
			encoder.Interlace = PngInterlaceOption.On;
			encoder.Frames.Add(BitmapFrame.Create(image));
			encoder.Save(stream);
			stream.Close();
		}
	}
}
