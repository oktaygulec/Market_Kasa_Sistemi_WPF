using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class KategoriRepository : ARepository<Kategori>, IDisposable
    {
        public KategoriRepository(DBContext context) : base(context) {}

        public override async Task<object> Add(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Kategori> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriGetById", new SqlParameter("@KategoriId", value)))
            {
                return await context.GetItem<Kategori>(cmd);
            }
        }

        public override async Task<int> Remove(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Kategori>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriGetAll"))
            {
                return await context.ToList<Kategori>(cmd);
            }
        }

        public override async Task<int> Update(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Kategori>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriGetAll"))
            {
                return await context.ToObservableCollection<Kategori>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
