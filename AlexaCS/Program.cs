namespace AlexaCS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if( System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("Já existe uma instância sendo executada!", "Alexa CS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

    }
}