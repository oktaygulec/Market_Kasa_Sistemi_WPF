using Market_Kasa_Sistemi.ModelLayer;
using Market_Kasa_Sistemi.WPF.ViewModels;
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

namespace Market_Kasa_Sistemi.WPF.Views
{
    /// <summary>
    /// Interaction logic for ZRaporuView.xaml
    /// </summary>
    public partial class ZRaporuView : Page
    {
        public ZRaporuView()
        {
            InitializeComponent();
            DataContext = new ZRaporuViewModel();
            dataGridFisler.Height = Application.Current.MainWindow.ActualHeight - 340;
        }

        private async void zRaporuView_Loaded(object sender, RoutedEventArgs e)
        {
            spinner.Visibility = Visibility.Visible;
            dataGridFisler.Visibility = Visibility.Hidden;
            await(DataContext as ZRaporuViewModel).GetDatas();
            spinner.Visibility = Visibility.Hidden;
            dataGridFisler.Visibility = Visibility.Visible;
        }
    }
}
