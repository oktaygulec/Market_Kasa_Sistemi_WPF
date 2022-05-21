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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class IadeViewModel : ViewModelBase
    {
        private ObservableCollection<SatisUrunViewModel> _items;
        public ObservableCollection<SatisUrunViewModel> Items 
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public decimal ToplamTutar
        {
            get => _items.Sum(x => x.Satis.ToplamKdvliFiyat);
        }

        public Visibility SpinnerVisibility { get; set; }
        public Visibility DataGridVisibility { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }
        public ICommand GetReceiptCommand { get; set; }
        public ICommand DoneCommand { get; set; }

        public IadeViewModel()
        {
            SetCommands();
            Items = new ObservableCollection<SatisUrunViewModel>();
        }

        private void SetCommands()
        {
            DeleteCommand = new RelayCommand(async satisUrunVM =>
            {
                Satis satis = (satisUrunVM as SatisUrunViewModel).Satis;
                if (satisUrunVM == null) return;

                var view = new DeleteItemDialog(new DeleteItemDialogViewModel
                {
                    Item = satis,
                    Title = "Satış sil",
                    Text = $"{satis.SatisAdet} adet {satis.UrunAd} adlı ürünü olan satışı silmek istiyor musunuz?"
                });

                var result = await DialogHost.Show(view);
                if ((bool)result)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        await uow.SatisRepository.Remove(satis);
                    }

                    Items.Remove(satisUrunVM as SatisUrunViewModel);
                    OnPropertyChanged("ToplamTutar");
                }
            });

            DecreaseCommand = new RelayCommand(async satisUrunVM =>
            {
                Satis satis = (satisUrunVM as SatisUrunViewModel).Satis;
                if ((satisUrunVM as SatisUrunViewModel).UrunAdet <= 1 || satisUrunVM == null) return;

                (satisUrunVM as SatisUrunViewModel).UrunAdet--;
                OnPropertyChanged("ToplamTutar");
                using (UnitOfWork uow = new UnitOfWork())
                {
                    await uow.SatisRepository.Update(satis);
                }
            });

            GetReceiptCommand = new RelayCommand(async o =>
            {
                var textBox = o as TextBox;

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    await DialogHost.Show(new InformationDialog("Hata", "Fiş alanı boş bırakılmamalı..."));
                    return;
                }

                SpinnerVisibility = Visibility.Visible;
                DataGridVisibility = Visibility.Hidden;
                OnPropertyChanged("SpinnerVisibility");
                OnPropertyChanged("DataGridVisibility");
                
                ObservableCollection<Satis> satislar;

                using (UnitOfWork uow = new UnitOfWork())
                {
                    satislar = await uow.SatisRepository.AllSatisByFisIdObservable(int.Parse(textBox.Text));
                }

                if (satislar.Count == 0)
                    await DialogHost.Show(new InformationDialog("Hata", "Fiş bulunamadı..."));
                else
                {
                    Items = new ObservableCollection<SatisUrunViewModel>();
                    foreach (var item in satislar)
                    {
                        Items.Add(new SatisUrunViewModel(item));
                    }
                    OnPropertyChanged("ToplamTutar");
                }

                SpinnerVisibility = Visibility.Hidden;
                DataGridVisibility = Visibility.Visible;
                OnPropertyChanged("SpinnerVisibility");
                OnPropertyChanged("DataGridVisibility");
                textBox.Text = "";
                textBox.Focus();
            });

            DoneCommand = new RelayCommand(o =>
            {
                Items.Clear();
            });
        }
    }
}
