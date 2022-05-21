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
    public class UrunlerViewModel : ViewModelBase
    {
        private ObservableCollection<Urun> _items;
        public ObservableCollection<Urun> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public UrunlerViewModel()
        {
            SetCommands();
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Items = await uow.UrunRepository.ToObservableCollection();
            }
        }

        private void SetCommands()
        {
            AddCommand = new RelayCommand(async o =>
            {
                var view = new UrunDialog();
                await DialogHost.Show(view);
                await GetDatas();
            });

            DeleteCommand = new RelayCommand(async o =>
            {
                var view = new DeleteItemDialog(new DeleteItemDialogViewModel
                {
                    Item = o as Urun,
                    Title = "Ürün sil",
                    Text = $"{(o as Urun).UrunAd} adlı ürünü silmek istiyor musunuz?"
                });

                var result = await DialogHost.Show(view);
                if ((bool)result)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        await uow.UrunRepository.Remove(o as Urun);
                    }
                }
                await GetDatas();
            });

            EditCommand = new RelayCommand(async o =>
            {
                Urun urun = o as Urun;
                var view = new UrunDialog(new UrunDialogViewModel(urun, Enums.ProcessType.Update));
                await DialogHost.Show(view);
                await GetDatas();
            });
        }
    }
}