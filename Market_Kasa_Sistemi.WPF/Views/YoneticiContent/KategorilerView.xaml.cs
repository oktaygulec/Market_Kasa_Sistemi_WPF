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
    /// Interaction logic for KategorilerView.xaml
    /// </summary>
    public partial class KategorilerView : Page
    {
        public KategorilerView()
        {
            InitializeComponent();
            DataContext = new KategorilerViewModel();
            dataGridKategoriler.Height = Application.Current.MainWindow.ActualHeight - 370;
        }

        private async void kategorilerView_Loaded(object sender, RoutedEventArgs e)
        {
            spinner.Visibility = Visibility.Visible;
            dataGridKategoriler.Visibility = Visibility.Hidden;
            await (DataContext as KategorilerViewModel).GetDatas();
            spinner.Visibility = Visibility.Hidden;
            dataGridKategoriler.Visibility = Visibility.Visible;
        }
    }
}
