using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScreenShotAgent
{
	public class FileManager
	{
		public static void SaveBitmap(BitmapSource image)
		{
			FileStream stream = new FileStream(DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "new.png", FileMode.Create);
			PngBitmapEncoder encoder = new PngBitmapEncoder();
			TextBlock myTextBlock = new TextBlock();
			myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
			encoder.Interlace = PngInterlaceOption.On;
			encoder.Frames.Add(BitmapFrame.Create(image));
			encoder.Save(stream);
			stream.Close();
		}
	}
}
