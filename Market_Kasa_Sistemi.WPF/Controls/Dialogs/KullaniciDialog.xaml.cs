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
    /// Interaction logic for KullaniciDialog.xaml
    /// </summary>
    public partial class KullaniciDialog : UserControl
    {
        public KullaniciDialog() : this(new KullaniciDialogViewModel(new Kullanici(), ProcessType.Add)) { }

        public KullaniciDialog(KullaniciDialogViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private async void kullaniciDialog_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as KullaniciDialogViewModel).GetDatas();
        }

        private void pswKullaniciSifre_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as KullaniciDialogViewModel).KullaniciSifre = ((PasswordBox)sender).Password;
        }
    }
}
