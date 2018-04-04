using ScreenshotBox.Forms;
using System;
using System.Windows;

namespace ScreenshotBox.Logic
{
	class ClipboardListener
	{
		private static object thisLock = new object();
		
		[STAThread]
		public void ClipboardNotification_ClipboardUpdatedEvent(object sender, EventArgs e)
		{
			try
			{
				if (Clipboard.ContainsImage()
					&& !Clipboard.ContainsText())
				{
					lock (thisLock)
					{
						var image = Clipboard.GetImage();
						var blinkWindow = ShowBlinkWindow();
						FileManager.SaveBitmap(image);
						blinkWindow.Hide();
					}
				}
			}
			catch (Exception)
			{
				// TODO: Log exceptions here
			}
		}

		private static Blink ShowBlinkWindow()
		{
			var blinkWindow = new Blink();
			blinkWindow.Show();
			blinkWindow.Topmost = true;

			return blinkWindow;
		}
	}
}
