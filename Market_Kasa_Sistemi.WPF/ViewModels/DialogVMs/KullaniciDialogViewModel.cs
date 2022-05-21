using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Enums;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs
{
    public class KullaniciDialogViewModel : ViewModelBase
    {
        public int KullaniciId { get; set; }

        private string _kullaniciAd;
        public string KullaniciAd { get => _kullaniciAd; set => SetProperty(ref _kullaniciAd, value); }

        private string _kullaniciSifre;
        public string KullaniciSifre { get => _kullaniciSifre; set => SetProperty(ref _kullaniciSifre, value); }

        private Personel _selectedPersonel;
        public Personel SelectedPersonel { get => _selectedPersonel; set => SetProperty(ref _selectedPersonel, value); }

        private List<Personel> _personeller;
        public List<Personel> Personeller { get => _personeller; set => SetProperty(ref _personeller, value); }

        public string ButtonText { get; set; }
        public ProcessType ProcessType { get; set; }
        public ICommand OKCommand { get; set; }

        public KullaniciDialogViewModel(Kullanici kullanici, ProcessType processType)
        {
            ButtonText = "EKLE";
            ProcessType = processType;
            OKCommand = new RelayCommand(OnOKCommand);

            if (processType == ProcessType.Update)
            {
                KullaniciId = kullanici.Id;
                KullaniciAd = kullanici.KullaniciAd;
                KullaniciSifre = kullanici.KullaniciSifre;
                SelectedPersonel = kullanici.Personel;
                ButtonText = "GÜNCELLE";
            }
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Personeller = await uow.PersonelRepository.ToList();
            }
        }

        private async void OnOKCommand(object o)
        {
            var dialogPage = o as KullaniciDialog;

            dialogPage.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (dialogPage.txtKullaniciAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (SelectedPersonel == null) return;

            Kullanici kullanici = new Kullanici
            {
                Id = KullaniciId,
                KullaniciAd = KullaniciAd,
                KullaniciSifre = KullaniciSifre,
                Personel = SelectedPersonel
            };

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (ProcessType == ProcessType.Add)
                    await uow.KullaniciRepository.Add(kullanici);
                else
                    await uow.KullaniciRepository.Update(kullanici);
            }

            DialogHost.Close(null);
        }
    }
}
