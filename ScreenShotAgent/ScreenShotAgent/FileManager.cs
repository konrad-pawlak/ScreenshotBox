using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ScreenshotBox
{
	public class FileManager
	{
		public static void SaveBitmap(BitmapSource image)
		{
			if (image == null)
				return; //Add logging if file logging.on exists

			var encoder = PngEncoder;
			encoder.Frames.Add(BitmapFrame.Create(image));

			var stream = new FileStream("screenshoot--" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss.fff") + ".png", FileMode.Create);
			//TODO: Add counter to the screen name if the screenshots were taken at the same second

			encoder.Save(stream);
			stream.Close();
		}

		private static PngBitmapEncoder PngEncoder
		{
			get
			{
				return new PngBitmapEncoder()
				{
					Interlace = PngInterlaceOption.On
				};
			}
		}
	}
}
