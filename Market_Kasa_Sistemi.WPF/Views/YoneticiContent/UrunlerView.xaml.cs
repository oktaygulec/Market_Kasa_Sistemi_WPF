using Market_Kasa_Sistemi.WPF.ViewModels.YoneticiVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market_Kasa_Sistemi.WPF.Views.YoneticiContent
{
    /// <summary>
    /// Interaction logic for UrunlerView.xaml
    /// </summary>
    public partial class UrunlerView : Page
    {
        public UrunlerView()
        {
            InitializeComponent();
            DataContext = new UrunlerViewModel();
            dataGridUrunler.Height = Application.Current.MainWindow.ActualHeight - 370;
        }

        private async void urunlerView_Loaded(object sender, RoutedEventArgs e)
        {
            spinner.Visibility = Visibility.Visible;
            dataGridUrunler.Visibility = Visibility.Hidden;
            await (DataContext as UrunlerViewModel).GetDatas();
            spinner.Visibility = Visibility.Hidden;
            dataGridUrunler.Visibility = Visibility.Visible;
        }
    }
}
