using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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


			//WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}
	}
}
