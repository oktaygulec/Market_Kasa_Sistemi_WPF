using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using Market_Kasa_Sistemi.WPF.Views;
using Market_Kasa_Sistemi.WPF.Views.UserViews;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels.UserVMs
{
    public class LoginViewModel : ViewModelBase
    {
        private string _kullaniciAd = "";
        public string KullaniciAd { get => _kullaniciAd; set => SetProperty(ref _kullaniciAd, value); }

        private string _kullaniciSifre = "";
        public string KullaniciSifre { get => _kullaniciSifre; set => SetProperty(ref _kullaniciSifre, value); }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public string LoginFrameSource = "/Views/UserViews/LoginView.xaml";
        public string RegisterFrameSource = "/Views/UserViews/RegisterView.xaml";

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async o =>
            {
                var loginView = o as LoginView;
                loginView.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (loginView.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;

                bool isLoggedIn;

                using (UnitOfWork uow = new UnitOfWork())
                {
                    isLoggedIn = await uow.KullaniciRepository.Login(KullaniciAd, KullaniciSifre);

                    App.Kullanici = await uow.KullaniciRepository.GetItem(KullaniciAd);
                }

                if (isLoggedIn)
                {
                    Window oldWindow = Application.Current.MainWindow;
                    Application.Current.MainWindow = new MainWindow();
                    Application.Current.MainWindow.Show();
                    oldWindow.Close();
                }
                else
                    await DialogHost.Show(new InformationDialog("Hata", "Kullanıcı adı veya şifre yanlış."));
            });

            RegisterCommand = new RelayCommand(o =>
            {
                (Application.Current.MainWindow as UserWindow).frmUser.Source = new Uri(RegisterFrameSource, UriKind.Relative);
            });
        }
    }
}
