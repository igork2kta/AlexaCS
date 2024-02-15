using Microsoft.Win32;

namespace FauxmoCS.Devices
{
    public static class AutoStartManager
    {
        private static readonly RegistryKey? Reg = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static void SetAutoStart(bool option)
        {
            Properties.Settings.Default.AutoStart = option;
            Properties.Settings.Default.Save();

            if (option)
                Reg?.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            else
                Reg?.DeleteValue(Application.ProductName);
        }
    }
}
