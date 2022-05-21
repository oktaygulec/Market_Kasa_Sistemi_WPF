using Market_Kasa_Sistemi.DatabaseAccessLayer;
using Market_Kasa_Sistemi.Models;
using Market_Kasa_Sistemi.WPF.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for BarkodOkuView.xaml
    /// </summary>
    public partial class BarkodOkuView : Page
    {
        public BarkodOkuView()
        {
            InitializeComponent();
        }

        private async void barkodTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            Urun urun;

            using (UnitOfWork uow = new UnitOfWork())
            {
                urun = await uow.UrunRepository.GetItem(barkodTxt.Text);
            }

            string title = urun.Id == 0 ? "Hata" : "Ürün bul";
            string text = urun.Id == 0
                ? "Ürün bulunamadı" 
                : $"Ürün adı: {urun.UrunAd}\n" +
                $"KDV'li ürün fiyatı: {urun.KdvliUrunFiyat.ToString("C2")}\n" +
                $"Ürün stok adeti: {urun.UrunStokAdet}\n" +
                $"Ürün kategorisi: {urun.KategoriAd}\n" +
                $"Ürün vergi miktarı: {urun.VergiMiktar}";

                await DialogHost.Show(new InformationDialog(title, text));
        }
    }
}
