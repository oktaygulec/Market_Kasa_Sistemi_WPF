using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.ModelLayer;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class ZRaporuViewModel : ViewModelBase
    {
        private ObservableCollection<ZRaporu> _items;
        public ObservableCollection<ZRaporu> Items 
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public decimal ToplamTutar { get => Items.Sum(x => x.ToplamFiyat); }

        public ICommand ExportReportCommand { get; set; }

        public ZRaporuViewModel()
        {
            ExportReportCommand = new RelayCommand(o => { });
        }

        public async Task GetDatas()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Items = await uow.SatisRepository.GetZReportObservable();
            }
            OnPropertyChanged("ToplamTutar");
        }
    }
}
