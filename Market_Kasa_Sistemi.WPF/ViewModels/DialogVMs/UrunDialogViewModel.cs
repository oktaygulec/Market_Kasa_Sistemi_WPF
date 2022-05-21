using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Enums;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs
{
    public class UrunDialogViewModel : ViewModelBase
    {
        public int UrunId { get; set; }

        private string _urunAd;
        public string UrunAd { get => _urunAd; set => SetProperty(ref _urunAd, value); }

        private decimal _urunFiyat;
        public decimal UrunFiyat { get => _urunFiyat; set => SetProperty(ref _urunFiyat, value); }

        private int _urunStokAdet;
        public int UrunStokAdet { get => _urunStokAdet; set => SetProperty(ref _urunStokAdet, value); }

        private Kategori _selectedKategori;
        public Kategori SelectedKategori { get => _selectedKategori; set => SetProperty(ref _selectedKategori, value); }

        private Vergi _selectedVergi;
        public Vergi SelectedVergi { get => _selectedVergi; set => SetProperty(ref _selectedVergi, value); }

        private List<Kategori> _kategoriler;
        public List<Kategori> Kategoriler { get => _kategoriler; set => SetProperty(ref _kategoriler, value); }

        private List<Vergi> _vergiler;
        public List<Vergi> Vergiler { get => _vergiler; set => SetProperty(ref _vergiler, value); }

        public string ButtonText { get; set; }
        public ProcessType ProcessType { get; set; }

        public ICommand OKCommand { get; set; }

        public UrunDialogViewModel(Urun urun, ProcessType processType)
        {
            ButtonText = "EKLE";
            ProcessType = processType;
            OKCommand = new RelayCommand(OnOKCommand);

            if (processType == ProcessType.Update)
            {
                UrunId = urun.Id;
                UrunAd = urun.UrunAd;
                UrunFiyat = urun.UrunFiyat;
                UrunStokAdet = urun.UrunStokAdet;
                SelectedKategori = urun.Kategori;
                SelectedVergi = urun.Vergi;
                ButtonText = "GÜNCELLE";
            }
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Kategoriler = await uow.KategoriRepository.ToList();
                Vergiler = await uow.VergiRepository.ToList();
            }
        }

        private async void OnOKCommand(object o)
        {
            var dialogPage = o as UrunDialog;

            dialogPage.txtUrunAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dialogPage.txtUrunFiyat.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dialogPage.txtUrunStokAdet.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (dialogPage.txtUrunAd.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (dialogPage.txtUrunFiyat.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (dialogPage.txtUrunStokAdet.GetBindingExpression(TextBox.TextProperty).HasValidationError) return;
            if (SelectedKategori == null) return;
            if (SelectedVergi == null) return;

            Urun urun = new Urun
            {
                Id = UrunId,
                UrunAd = UrunAd,
                UrunFiyat = UrunFiyat,
                UrunStokAdet = UrunStokAdet,
                Kategori = SelectedKategori,
                Vergi = SelectedVergi
            };

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (ProcessType == ProcessType.Add)
                    await uow.UrunRepository.Add(urun);
                else
                    await uow.UrunRepository.Update(urun);
            }

            DialogHost.Close(null);
        }
    }
}
