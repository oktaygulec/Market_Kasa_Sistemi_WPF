using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class SatisUrunViewModel : ViewModelBase
    {
        private Urun _urun;
        public Urun Urun { get => _urun; }

        public int Id 
        {
            get => _urun.Id;
            set 
            {
                if(_urun.Id != value)
                {
                    _urun.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UrunAd
        {
            get => _urun.UrunAd;
            set
            {
                if (_urun.UrunAd != value)
                {
                    _urun.UrunAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal UrunFiyat
        {
            get => _urun.UrunFiyat;
            set
            {
                if (_urun.UrunFiyat != value)
                {
                    _urun.UrunFiyat = value;
                    OnPropertyChanged();
                }
            }
        }

        public int UrunStokAdet
        {
            get => _urun.UrunStokAdet;
            set
            {
                if (_urun.UrunStokAdet != value)
                {
                    _urun.UrunStokAdet = value;
                    OnPropertyChanged();
                }
            }
        }

        public Kategori Kategori
        {
            get => _urun.Kategori;
            set
            {
                if (_urun.Kategori != value)
                {
                    _urun.Kategori = value;
                    OnPropertyChanged();
                }
            }
        }

        public Vergi Vergi
        {
            get => _urun.Vergi;
            set
            {
                if (_urun.Vergi != value)
                {
                    _urun.Vergi = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatisUrunViewModel() : this(new Urun()){}

        public SatisUrunViewModel(Urun urun)
        {
            this._urun = urun;
        }
    }
}
