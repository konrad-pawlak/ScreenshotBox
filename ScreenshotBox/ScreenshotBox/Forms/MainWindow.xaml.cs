using ScreenshotBox.Logic;
using System.Windows;

namespace ScreenshotBox.Forms
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TrayHelper _trayHelper = null;
		ClipboardListener _clipboardListener = null;

		public MainWindow()
		{
			if (ProcessHelper.IsAnotherProcessRunning())
			{
				CloseApplication(messageForUser: "Another instance is already running");
				return;
			}

			InitializeComponent();
			Hide();

			PrepareClipboardListener();
			PrepareTrayIcon();

			RegisterWindowEvents();
		}

		private void CloseApplication(string messageForUser)
		{
			MessageBox.Show(messageForUser);
			this.Close();
		}

		private void PrepareTrayIcon()
		{
			_trayHelper = new TrayHelper(this);
			_trayHelper.PrepareNotificationIcon();
		}

		private void PrepareClipboardListener()
		{
			_clipboardListener = new ClipboardListener();
			ClipboardNotification.ClipboardUpdatedEvent
				+= _clipboardListener.ClipboardNotification_ClipboardUpdatedEvent;
		}

		private void RegisterWindowEvents()
		{
			Closing += MainWindow_Closing;
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_trayHelper.HideNotifyIcon();
		}
	}
}
