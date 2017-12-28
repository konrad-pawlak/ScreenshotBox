using System.Windows;
using System.Windows.Forms;

namespace ScreenShotAgent
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		NotifyIcon notifyIcon = new NotifyIcon();

		public MainWindow()
		{
			InitializeComponent();
			Closing += MainWindow_Closing;

			MinimizeAppToNotifyArea();
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon.Visible = false;
		}

		private void MinimizeAppToNotifyArea()
		{
			WindowState = WindowState.Minimized;

			notifyIcon.Icon = Properties.Resources.status_bar_icon;
			notifyIcon.ShowBalloonTip(5000, "Hi", "This is a BallonTip from Windows Notification", ToolTipIcon.Info);
			notifyIcon.Visible = true;
		}
	}
}
