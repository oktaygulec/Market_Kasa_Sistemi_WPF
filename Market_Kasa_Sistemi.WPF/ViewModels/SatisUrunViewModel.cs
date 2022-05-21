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
        private Satis _satis;
        public Satis Satis { get => _satis; }

        public decimal ToplamFiyat { get => _satis.ToplamKdvliFiyat; }

        public int UrunAdet
        {
            get => _satis.SatisAdet;
            set
            {
                if (_satis.SatisAdet != value)
                {
                    _satis.SatisAdet = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ToplamFiyat");
                }
            }
        }

        public SatisUrunViewModel() : this(new Satis()){}

        public SatisUrunViewModel(Satis satis)
        {
            this._satis = satis;
        }
    }
}
