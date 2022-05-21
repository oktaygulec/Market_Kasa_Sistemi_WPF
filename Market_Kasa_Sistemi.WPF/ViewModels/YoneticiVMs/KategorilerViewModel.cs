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
    public class KategorilerViewModel : ViewModelBase
    {
        private ObservableCollection<Kategori> _items;
        public ObservableCollection<Kategori> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public KategorilerViewModel()
        {
            SetCommands();
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Items = await uow.KategoriRepository.ToObservableCollection();
            }
        }

        private void SetCommands()
        {
            AddCommand = new RelayCommand(async o =>
            {
                var view = new KategoriDialog();
                await DialogHost.Show(view);
                await GetDatas();
            });

            DeleteCommand = new RelayCommand(async o =>
            {
                var view = new DeleteItemDialog(new DeleteItemDialogViewModel {
                    Item = o as Kategori,
                    Title = "Kategori sil",
                    Text = $"{(o as Kategori).KategoriAd} adlı kategoriyi silmek istiyor musunuz?"
                });

                var result = await DialogHost.Show(view);
                if ((bool)result)
                {
                    using(UnitOfWork uow = new UnitOfWork())
                    {
                        await uow.KategoriRepository.Remove(o as Kategori);
                    }
                }
                await GetDatas();
            });

            EditCommand = new RelayCommand(async o =>
            {
                Kategori kategori = o as Kategori;
                var view = new KategoriDialog(new KategoriDialogViewModel(kategori, Enums.ProcessType.Update));
                await DialogHost.Show(view);
                await GetDatas();
            });
        }
    }
}
