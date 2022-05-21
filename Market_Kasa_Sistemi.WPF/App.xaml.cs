using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.ViewModels.UserVMs;
using Market_Kasa_Sistemi.WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Market_Kasa_Sistemi.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Kullanici Kullanici { get; set; }

        public App()
        {
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // check if it's logged in before
            Window login = new UserWindow(Enums.UserWindowType.Login);
            login.Show();
        }
    }
}
