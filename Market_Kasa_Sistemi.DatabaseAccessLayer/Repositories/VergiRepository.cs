using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class VergiRepository : ARepository<Vergi>, IDisposable
    {
        public VergiRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Vergi item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Vergi> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiGetById", new SqlParameter("@VergiId", value)))
            {
                return await context.GetItem<Vergi>(cmd);
            }
        }

        public override async Task<int> Remove(Vergi item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Vergi>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiGetAll"))
            {
                return await context.ToList<Vergi>(cmd);
            }
        }

        public override async Task<int> Update(Vergi item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Vergi>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPVergiGetAll"))
            {
                return await context.ToObservableCollection<Vergi>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
