using System;
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
			Hide();

			PrepareNotificationIcon();
			RegisterWindowEvents();

			PrintScreenListener.StartListening();
		}

		private void PrepareNotificationIcon()
		{
			CreateNotificationIcon();
			SetContextMenuForNotificationIcon();
		}

		private void CreateNotificationIcon()
		{
			notifyIcon.Icon = Properties.Resources.status_bar_icon;
			notifyIcon.Visible = true;
			notifyIcon.Text = "ScreenShot Agent";
		}

		private void SetContextMenuForNotificationIcon()
		{
			notifyIcon.ContextMenu = new ContextMenu();
			notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("Settings", OpenSettigns));
			notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("Exit", CloseApplication));
		}

		private void OpenSettigns(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void CloseApplication(object sender, EventArgs e)
		{
			Close();
		}

		private void RegisterWindowEvents()
		{
			Closing += MainWindow_Closing;
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon.Visible = false;
		}
	}
}
