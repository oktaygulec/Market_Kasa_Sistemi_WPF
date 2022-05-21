using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using MaterialDesignThemes.Wpf;
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
        public ObservableCollection<SatisUrunViewModel> Items { get => _items; set => SetProperty(ref _items, value); }

        private List<OdemeTip> _odemeTipler;
        public List<OdemeTip> OdemeTipler { get => _odemeTipler; set => SetProperty(ref _odemeTipler, value); }

        private OdemeTip _selectedOdemeTip;
        public OdemeTip SelectedOdemeTip { get => _selectedOdemeTip; set => SetProperty(ref _selectedOdemeTip, value); }

        public decimal ToplamTutar { get => _items.Sum(x => x.Satis.ToplamKdvliFiyat); }

        public ICommand DeleteCommand { get; set; }
        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand MakeSaleCommand { get; set; }
        public ICommand AddUrunCommand { get; set; }

        public SatisViewModel()
        {
            SetCommands();

            Items = new ObservableCollection<SatisUrunViewModel>();
        }

        public async Task GetOdemeTipler()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                OdemeTipler = await uow.OdemeTipRepository.ToList();
            }
        }

        private void SetCommands()
        {
            DeleteCommand = new RelayCommand(satis => {
                if (satis != null)
                {
                    Items.Remove(satis as SatisUrunViewModel);
                    OnPropertyChanged("ToplamTutar");
                }
            });

            IncreaseCommand = new RelayCommand(satis => {
                if (satis != null)
                {
                    (satis as SatisUrunViewModel).UrunAdet++;
                    OnPropertyChanged("ToplamTutar");
                }
            });

            DecreaseCommand = new RelayCommand(satis => {
                if (satis != null && (satis as SatisUrunViewModel).UrunAdet > 1)
                {
                    (satis as SatisUrunViewModel).UrunAdet--;
                    OnPropertyChanged("ToplamTutar");
                }
            });

            ResetCommand = new RelayCommand(o => {
                Items = new ObservableCollection<SatisUrunViewModel>();
                OnPropertyChanged("ToplamTutar");
            });

            MakeSaleCommand = new RelayCommand(async o => {
                if (Items.Count == 0)
                {
                    return;
                }

                if (SelectedOdemeTip == null)
                {
                    return;
                }

                Fis newFis;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    newFis = new Fis
                    {
                        FisTarih = DateTime.Now,
                        Personel = await uow.PersonelRepository.GetItem(App.Kullanici.Personel.Id),
                        OdemeTip = SelectedOdemeTip
                    };

                    newFis.Id = Convert.ToInt32(await uow.FisRepository.Add(newFis));

                    foreach (var item in Items)
                    {
                        item.Satis.Fis = newFis;
                        await uow.SatisRepository.Add(item.Satis);
                    }
                }
                var view = new InformationDialog("Satış", $"Satış tamamlandı. Fiş {newFis.Id}");
                await DialogHost.Show(view);
                Items = new ObservableCollection<SatisUrunViewModel>();
                OnPropertyChanged("ToplamTutar");
            });

            AddUrunCommand = new RelayCommand(async o => {
                var textBox = o as TextBox;

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    var view = new InformationDialog("Hata", "Ürün alanı boş bırakılmamalıdır...");
                    await DialogHost.Show(view);
                    textBox.Focus();
                    return;
                }
                
                Urun urun;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    urun = await uow.UrunRepository.GetItem(int.Parse(textBox.Text));
                }
                if (urun.Id == 0)
                {
                    var view = new InformationDialog("Hata", "Ürün bulunamadı...");
                    await DialogHost.Show(view);
                    textBox.Text = "";
                    textBox.Focus();
                    return;
                }
                if(urun.UrunStokAdet <= 0)
                {
                    var view = new InformationDialog("Hata", "Ürün stokta yok...");
                    await DialogHost.Show(view);
                    textBox.Text = "";
                    textBox.Focus();
                    return;
                }

                var satis = Items.FirstOrDefault(x => x.Satis.UrunBarkod == urun.Id);
                if (satis == null)
                    Items.Add(new SatisUrunViewModel(new Satis { SatisAdet = 1, Fis = new Fis(), Urun = urun }));
                else
                    satis.UrunAdet++;

                OnPropertyChanged("ToplamTutar");
                textBox.Text = "";
                textBox.Focus();
            });
        }
    }
}
