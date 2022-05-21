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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
            txtKullaniciAd.Focus();
        }

        private async void registerView_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as RegisterViewModel).GetDatas();
        }

        private void pswKullaniciSifre_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterViewModel).KullaniciSifre = (sender as PasswordBox).Password;
        }
    }
}
