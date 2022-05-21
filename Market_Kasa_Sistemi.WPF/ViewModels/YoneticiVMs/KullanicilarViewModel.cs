using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels.YoneticiVMs
{
    public class KullanicilarViewModel : ViewModelBase
    {
        private ObservableCollection<Kullanici> _items;
        public ObservableCollection<Kullanici> Items 
        { 
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public KullanicilarViewModel()
        {
            SetCommands();
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Items = await uow.KullaniciRepository.ToObservableCollection();
            }
        }

        private void SetCommands()
        {
            AddCommand = new RelayCommand(async o =>
            {
                var view = new KullaniciDialog();
                await DialogHost.Show(view);
                await GetDatas();
            });

            DeleteCommand = new RelayCommand(async o => 
            {
                var view = new DeleteItemDialog(new DeleteItemDialogViewModel
                {
                    Item = o as Kullanici,
                    Title = "Kullanıcı sil",
                    Text = $"{(o as Kullanici).KullaniciAd} adlı kullanıcıyı silmek istiyor musunuz?"
                });

                var result = await DialogHost.Show(view);
                if ((bool)result)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        await uow.KullaniciRepository.Remove(o as Kullanici);
                    }
                }
                await GetDatas();
            });

            EditCommand = new RelayCommand(async o =>
            {
                Kullanici kullanici = o as Kullanici;
                var view = new KullaniciDialog(new KullaniciDialogViewModel(kullanici, Enums.ProcessType.Update));
                await DialogHost.Show(view);
                await GetDatas();
            });
        }
    }
}
