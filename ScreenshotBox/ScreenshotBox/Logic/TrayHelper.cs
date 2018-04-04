using ScreenshotBox.Forms;
using System;
using System.Windows;
using System.Windows.Forms;

namespace ScreenshotBox.Logic
{
	class TrayHelper
	{
		Window _mainWindow = null;
		NotifyIcon _notifyIcon = null;

		public TrayHelper(Window mainWindow)
		{
			_mainWindow = mainWindow;
		}

		public void PrepareNotificationIcon()
		{
			_notifyIcon = new NotifyIcon();

			CreateNotificationIcon();
			SetContextMenuForNotificationIcon();
		}

		private void CreateNotificationIcon()
		{
			_notifyIcon.Icon = Properties.Resources.status_bar_icon;
			_notifyIcon.Visible = true;
			_notifyIcon.Text = "ScreenshotBox";
		}

		private void SetContextMenuForNotificationIcon()
		{
			_notifyIcon.ContextMenu = new ContextMenu();
			_notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("Settings", OpenSettigns));
			_notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("About", OpenAboutWindow));
			_notifyIcon.ContextMenu.MenuItems.Add(new MenuItem("Exit", CloseApplication));
		}

		private void OpenAboutWindow(object sender, EventArgs e)
		{
			var aboutWindow = new About();
			aboutWindow.Show();
		}

		private void OpenSettigns(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void CloseApplication(object sender, EventArgs e)
		{
			_mainWindow.Close();
		}

		public void HideNotifyIcon()
		{
			_notifyIcon.Visible = false;
		}
	}
}
