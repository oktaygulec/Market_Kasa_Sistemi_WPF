using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class FisRepository : ARepository<Fis>, IDisposable
    {
        public FisRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Fis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Fis> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisGetById", new SqlParameter("@FisId", value)))
            {
                return await context.GetItem<Fis>(cmd);
            }
        }

        public override async Task<int> Remove(Fis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Fis>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisGetAll"))
            {
                return await context.ToList<Fis>(cmd);
            }
        }

        public override async Task<int> Update(Fis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Fis>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPFisGetAll"))
            {
                return await context.ToObservableCollection<Fis>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
