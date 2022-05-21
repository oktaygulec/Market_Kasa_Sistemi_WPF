using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class UrunRepository : ARepository<Urun>, IDisposable
    {
        public UrunRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Urun item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Urun> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunGetById", new SqlParameter("@UrunBarkod", value)))
            {
                return await context.GetItem<Urun>(cmd);
            }
        }

        public override async Task<int> Remove(Urun item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Urun>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunGetAll"))
            {
                return await context.ToList<Urun>(cmd);
            }
        }

        public override async Task<int> Update(Urun item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Urun>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPUrunGetAll"))
            {
                return await context.ToObservableCollection<Urun>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
