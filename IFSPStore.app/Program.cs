using IFSPStore.app.Infra;

namespace IFSPStore.app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // dependency injection config
            ConfigureDI.ConfigureServices();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}