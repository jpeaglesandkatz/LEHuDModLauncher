using LEHuDModLauncher;
using Microsoft.VisualBasic.Logging;
using LogUtils;

namespace LEHudModLauncher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger dlog = new Logger();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            dlog.Info("==================== Launcher started ========================");
            Application.Run(new launcherform());
        }
    }
}