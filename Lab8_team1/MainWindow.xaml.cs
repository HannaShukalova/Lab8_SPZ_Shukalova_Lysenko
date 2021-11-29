using System.Windows;
using Microsoft.Win32;

namespace Lab8_team1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetRegistryData();
        }

        public void GetRegistryData()
        {
            RegistryKey keyBIOS = Registry.LocalMachine.OpenSubKey("HARDWARE").OpenSubKey("DESCRIPTION").OpenSubKey("SYSTEM").OpenSubKey("BIOS");
            lbBiosVersion.Content = "BIOS Version: " + keyBIOS?.GetValue("BIOSVersion")?.ToString();
            lbBiosVendor.Content = "BIOS Vendor: " + keyBIOS?.GetValue("BIOSVendor")?.ToString();
            keyBIOS.Close();

            RegistryKey keyCPU = Registry.LocalMachine.OpenSubKey("HARDWARE").OpenSubKey("DESCRIPTION").OpenSubKey("SYSTEM").
                OpenSubKey("CentralProcessor").OpenSubKey("0");
            lbBiosCpuType.Content = "CPU type: " + keyCPU?.GetValue("Identifier")?.ToString();
            keyCPU.Close();
        }
    }
}
