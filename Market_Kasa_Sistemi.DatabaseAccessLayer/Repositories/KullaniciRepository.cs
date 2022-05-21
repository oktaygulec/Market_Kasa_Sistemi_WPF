using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class KullaniciRepository : ARepository<Kullanici>, IDisposable
    {
        public KullaniciRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Kullanici item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Kullanici> GetItem(object value)
        {
            using (
                SqlCommand cmd =
                value.GetType() == typeof(int)
                ? context.CreateCommand("SPKullaniciGetById", new SqlParameter("@KullaniciId", value))
                : context.CreateCommand("SPKullaniciGetByAd", new SqlParameter("@KullaniciAd", value))
                )
            {
                return await context.GetItem<Kullanici>(cmd);
            }
        }

        public override async Task<int> Remove(Kullanici item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Kullanici>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciGetAll"))
            {
                return await context.ToList<Kullanici>(cmd);
            }
        }

        public override async Task<int> Update(Kullanici item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public async Task<bool> Login(string kullaniciAd, string kullaniciSifre)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciLogin"))
            {
                cmd.Parameters.AddWithValue("KullaniciAd", kullaniciAd);
                cmd.Parameters.AddWithValue("KullaniciSifre", kullaniciSifre);
                return Convert.ToBoolean(await context.ExecuteScalar(cmd));
            }
        }

        public override async Task<ObservableCollection<Kullanici>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPKullaniciGetAll"))
            {
                return await context.ToObservableCollection<Kullanici>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
