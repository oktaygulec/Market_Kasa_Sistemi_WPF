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
    /// Interaction logic for PersonellerView.xaml
    /// </summary>
    public partial class PersonellerView : Page
    {
        public PersonellerView()
        {
            InitializeComponent();
            DataContext = new PersonellerViewModel();
            dataGridPersoneller.Height = Application.Current.MainWindow.ActualHeight - 370;
        }

        private async void personellerView_Loaded(object sender, RoutedEventArgs e)
        {
            spinner.Visibility = Visibility.Visible;
            dataGridPersoneller.Visibility = Visibility.Hidden;
            await (DataContext as PersonellerViewModel).GetDatas();
            spinner.Visibility = Visibility.Hidden;
            dataGridPersoneller.Visibility = Visibility.Visible;
        }
    }
}
