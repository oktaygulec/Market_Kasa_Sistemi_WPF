using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class OdemeTipRepository : ARepository<OdemeTip>, IDisposable
    {
        public OdemeTipRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(OdemeTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<OdemeTip> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipGetById", new SqlParameter("@OdemeTipId", value)))
            {
                return await context.GetItem<OdemeTip>(cmd);
            }
        }

        public override async Task<int> Remove(OdemeTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<OdemeTip>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipGetAll"))
            {
                return await context.ToList<OdemeTip>(cmd);
            }
        }

        public override async Task<int> Update(OdemeTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<OdemeTip>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPOdemeTipGetAll"))
            {
                return await context.ToObservableCollection<OdemeTip>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
