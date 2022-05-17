using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class SatisViewModel : ViewModelBase
    {
        private ObservableCollection<SatisUrunViewModel> _items;
        public ObservableCollection<SatisUrunViewModel> Items 
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public decimal ToplamTutar
        {
            get => _items.Sum(x => x.Urun.KdvliUrunFiyat * x.Urun.UrunStokAdet);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }

        public SatisViewModel()
        {
            SetCommands();

            Items = new ObservableCollection<SatisUrunViewModel>
            {
                new SatisUrunViewModel(new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                }),
                new SatisUrunViewModel(new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                }),
            };
        }

        private void SetCommands()
        {
            DeleteCommand = new RelayCommand(urun => {
                if (urun != null)
                {
                    Items.Remove(urun as SatisUrunViewModel);
                    OnPropertyChanged("ToplamTutar");
                }
            });

            IncreaseCommand = new RelayCommand(urun => {
                if (urun != null)
                {
                    (urun as SatisUrunViewModel).UrunStokAdet++;
                }
            });

            DecreaseCommand = new RelayCommand(urun => {
                if (urun != null && (urun as SatisUrunViewModel).UrunStokAdet > 1)
                {
                    (urun as SatisUrunViewModel).UrunStokAdet--;
                }
            });
        }
    }
}
