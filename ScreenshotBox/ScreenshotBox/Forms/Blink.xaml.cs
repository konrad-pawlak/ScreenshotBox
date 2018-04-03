using System.Windows;

namespace ScreenshotBox.Forms
{
	/// <summary>
	/// Interaction logic for Blink.xaml
	/// </summary>
	public partial class Blink : Window
	{
		public Blink()
		{
			InitializeComponent();

			var desktopWorkingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			this.Left = desktopWorkingArea.Right - this.Width;
			this.Top = desktopWorkingArea.Bottom - this.Height;
		}
	}
}
