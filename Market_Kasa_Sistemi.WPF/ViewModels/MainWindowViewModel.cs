using Market_Kasa_Sistemi.WPF.Controls;
using Market_Kasa_Sistemi.WPF.ViewModels.Base;
using Market_Kasa_Sistemi.WPF.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<DrawerListItem> Items { get; }

        public DrawerListItem _selectedItem;
        public DrawerListItem SelectedItem 
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<DrawerListItem>
            {
                new DrawerListItem { Text = "SATIŞ", Icon = PackIconKind.CashRegister, Source = "/Views/SatisView.xaml" },
                new DrawerListItem { Text = "BARKOD OKU", Icon = PackIconKind.Magnify, Source = "/Views/BarkodOkuView.xaml" },
                new DrawerListItem { Text = "İADE ET", Icon = PackIconKind.CashReturn, Source = "/Views/IadeView.xaml" },
                new DrawerListItem { Text = "Z RAPORU", Icon = PackIconKind.Newspaper, Source = "/Views/ZRaporuView.xaml" },
                new DrawerListItem { Text = "YÖNETİCİ MENÜSÜ", Icon = PackIconKind.Settings, Source = "/Views/YoneticiView.xaml" },
            };
            SelectedItem = Items[0];
        }
    }
}
