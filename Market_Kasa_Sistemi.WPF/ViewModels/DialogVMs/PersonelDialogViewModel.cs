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
    public class PersonelDialogViewModel : ViewModelBase
    {
        public int PersonelId { get; set; }

        private string _personelAd;
        public string PersonelAd { get => _personelAd; set => SetProperty(ref _personelAd, value); }
        
        private string _personelSoyad;
        public string PersonelSoyad { get => _personelSoyad; set => SetProperty(ref _personelSoyad, value); }

        private DateTime _personelBaslangicTarih = DateTime.Now;
        public DateTime PersonelBaslangicTarih { get => _personelBaslangicTarih; set => SetProperty(ref _personelBaslangicTarih, value); }

        private PersonelTip _selectedPersonelTip;
        public PersonelTip SelectedPersonelTip { get => _selectedPersonelTip; set => SetProperty(ref _selectedPersonelTip, value); }

        private List<PersonelTip> _personelTipler;
        public List<PersonelTip> PersonelTipler { get => _personelTipler; set => SetProperty(ref _personelTipler, value); }

        public string ButtonText { get; set; }
        public ProcessType ProcessType { get; set; }
        public ICommand OKCommand { get; set; }

        public PersonelDialogViewModel(Personel personel, ProcessType processType)
        {
            ButtonText = "EKLE";
            ProcessType = processType;
            OKCommand = new RelayCommand(OnOKCommand);

            if(processType == ProcessType.Update)
            {
                PersonelId = personel.Id;
                PersonelAd = personel.PersonelAd;
                PersonelSoyad = personel.PersonelSoyad;
                PersonelBaslangicTarih = personel.PersonelBaslangicTarih;
                SelectedPersonelTip = personel.PersonelTip;
                ButtonText = "GÜNCELLE";
            }
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                PersonelTipler = await uow.PersonelTipRepository.ToList();
            }
        }

        private async void OnOKCommand(object o)
        {
            var dialogPage = o as PersonelDialog;

            dialogPage.txtPersonelAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dialogPage.txtPersonelSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dialogPage.datePickerPersonelBaslangic.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();

            if (dialogPage.txtPersonelAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (dialogPage.txtPersonelSoyad.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (dialogPage.datePickerPersonelBaslangic.GetBindingExpression(DatePicker.SelectedDateProperty).HasValidationError) return;
            if (SelectedPersonelTip == null) return;

            Personel personel = new Personel
            {
                Id = PersonelId,
                PersonelAd = PersonelAd,
                PersonelSoyad = PersonelSoyad,
                PersonelBaslangicTarih = PersonelBaslangicTarih,
                PersonelTip = SelectedPersonelTip
            };

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (ProcessType == ProcessType.Add)
                    await uow.PersonelRepository.Add(personel);
                else
                    await uow.PersonelRepository.Update(personel);
            }

            DialogHost.Close(null);
        }
    }
}
