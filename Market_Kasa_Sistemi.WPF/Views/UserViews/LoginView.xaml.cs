using Market_Kasa_Sistemi.WPF.ViewModels.UserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market_Kasa_Sistemi.WPF.Views.UserViews
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            txtKullaniciAd.Focus();
        }

        private void pswKullaniciSifre_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).KullaniciSifre = (sender as PasswordBox).Password;
        }
    }
}
