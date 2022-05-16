using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.WPF.ViewModels
{
    public class SatisViewModel
    {
        public ObservableCollection<Urun> Items { get; set; }

        public SatisViewModel()
        {
            Items = new ObservableCollection<Urun>
            {
                new Urun 
                { 
                    Id = 201601006, 
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M, 
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601006,
                    UrunAd = "PATATES",
                    UrunFiyat = 9.99M,
                    UrunStokAdet = 1,
                    Kategori = new Kategori
                    {
                        Id = 1,
                        KategoriAd = "YİYECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
                new Urun
                {
                    Id = 201601007,
                    UrunAd = "SU",
                    UrunFiyat = 5.99M,
                    UrunStokAdet = 2,
                    Kategori = new Kategori
                    {
                        Id = 2,
                        KategoriAd = "İÇECEK"
                    },
                    Vergi = new Vergi { Id = 1, VergiMiktar = 8 }
                },
            };
        }
    }
}
