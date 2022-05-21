using Market_Kasa_Sistemi.Enums;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.ViewModels.DialogVMs;
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

namespace Market_Kasa_Sistemi.WPF.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for PersonelDialog.xaml
    /// </summary>
    public partial class PersonelDialog : UserControl
    {
        public PersonelDialog() : this(new PersonelDialogViewModel(new Personel(), ProcessType.Add)) { }

        public PersonelDialog(PersonelDialogViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private async void personelDialog_Loaded(object sender, RoutedEventArgs e)
        {
            await(DataContext as PersonelDialogViewModel).GetDatas();
        }
    }
}
