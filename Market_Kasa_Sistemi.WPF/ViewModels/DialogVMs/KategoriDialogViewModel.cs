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
    public class KategoriDialogViewModel : ViewModelBase
    {
        public int KategoriId { get; set; }

        private string _kategoriAd;
        public string KategoriAd { get => _kategoriAd; set => SetProperty(ref _kategoriAd, value); }

        public string ButtonText { get; set; }
        public ProcessType ProcessType { get; set; }

        public ICommand OKCommand { get; set; }

        public KategoriDialogViewModel(Kategori kategori, ProcessType processType)
        {
            ProcessType = processType;
            ButtonText = ProcessType == ProcessType.Add ? "EKLE" : "GÜNCELLE";
            KategoriAd = kategori.KategoriAd;

            OKCommand = new RelayCommand(OnOKCommand);
        }

        private async void OnOKCommand(object o)
        {
            var dialogPage = o as KategoriDialog;

            dialogPage.txtKategoriAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (dialogPage.txtKategoriAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (ProcessType == ProcessType.Add)
                    await uow.KategoriRepository.Add(new Kategori { KategoriAd = KategoriAd });
                else
                    await uow.KategoriRepository.Update(new Kategori { Id = KategoriId, KategoriAd = KategoriAd});
            }

            DialogHost.Close(null);
        }
    }
}
