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
    public class RegisterViewModel : ViewModelBase
    {
        private string _kullaniciAd = "";
        public string KullaniciAd { get => _kullaniciAd; set => SetProperty(ref _kullaniciAd, value); }

        private string _kullaniciSifre = "";
        public string KullaniciSifre { get => _kullaniciSifre; set => SetProperty(ref _kullaniciSifre, value); }

        private Personel _selectedPersonel;
        public Personel SelectedPersonel { get => _selectedPersonel; set => SetProperty(ref _selectedPersonel, value); }

        private List<Personel> _personeller;
        public List<Personel> Personeller { get => _personeller; set => SetProperty(ref _personeller, value); }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public string LoginFrameSource = "/Views/UserViews/LoginView.xaml";
        public string RegisterFrameSource = "/Views/UserViews/RegisterView.xaml";

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(async o =>
            {
                var registerView = o as RegisterView;
                registerView.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (registerView.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
                if (String.IsNullOrWhiteSpace(registerView.pswKullaniciSifre.Password)) return;
                if (SelectedPersonel == null) return;

                
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Kullanici getKullanici = await uow.KullaniciRepository.GetItem(KullaniciAd);
                    if (getKullanici.Id == 0)
                    {
                        Kullanici newKullanici = new Kullanici { KullaniciAd = KullaniciAd, KullaniciSifre = KullaniciSifre, Personel = SelectedPersonel };
                        await uow.KullaniciRepository.Add(newKullanici);
                        (Application.Current.MainWindow as UserWindow).frmUser.Source = new Uri(LoginFrameSource, UriKind.Relative);
                    }
                    else
                        await DialogHost.Show(new InformationDialog("Hata", "Böyle bir kullanıcı zaten var."));
                }
            });

            LoginCommand = new RelayCommand(o =>
            {
                (Application.Current.MainWindow as UserWindow).frmUser.Source = new Uri(LoginFrameSource, UriKind.Relative);
            });
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Personeller = await uow.PersonelRepository.ToList();
            }
        }
    }
}
