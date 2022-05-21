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
    public class PersonellerViewModel : ViewModelBase
    {
        private ObservableCollection<Personel> _items;
        public ObservableCollection<Personel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public PersonellerViewModel()
        {
            SetCommands();
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Items = await uow.PersonelRepository.ToObservableCollection();
            }
        }

        private void SetCommands()
        {
            AddCommand = new RelayCommand(async o =>
            {
                var view = new PersonelDialog();
                await DialogHost.Show(view);
                await GetDatas();
            });

            DeleteCommand = new RelayCommand(async o =>
            {
                var view = new DeleteItemDialog(new DeleteItemDialogViewModel
                {
                    Item = o as Personel,
                    Title = "Personel sil",
                    Text = $"{(o as Personel).PersonelAdSoyad} adlı personeli silmek istiyor musunuz?"
                });

                var result = await DialogHost.Show(view);
                if ((bool)result)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        await uow.PersonelRepository.Remove(o as Personel);
                    }
                }
                await GetDatas();
            });

            EditCommand = new RelayCommand(async o =>
            {
                Personel personel = o as Personel;
                var view = new PersonelDialog(new PersonelDialogViewModel(personel, Enums.ProcessType.Update));
                await DialogHost.Show(view);
                await GetDatas();
            });
        }
    }
}

