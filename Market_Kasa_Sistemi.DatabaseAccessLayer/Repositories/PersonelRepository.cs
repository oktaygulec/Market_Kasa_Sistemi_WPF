using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class PersonelRepository : ARepository<Personel>, IDisposable
    {
        public PersonelRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Personel> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelGetById", new SqlParameter("@PersonelId", value)))
            {
                return await context.GetItem<Personel>(cmd);
            }
        }

        public override async Task<int> Remove(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Personel>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelGetAll"))
            {
                return await context.ToList<Personel>(cmd);
            }
        }

        public override async Task<int> Update(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Personel>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelGetAll"))
            {
                return await context.ToObservableCollection<Personel>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
