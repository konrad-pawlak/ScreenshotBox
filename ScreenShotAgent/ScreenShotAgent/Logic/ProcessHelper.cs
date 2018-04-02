using System.Diagnostics;

namespace ScreenshotBox.Logic
{
	class ProcessHelper
	{
		internal static bool IsAnotherProcessRunning()
		{
			var anotherProcesses = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
			return anotherProcesses.Length > 1;
		}
	}
}
