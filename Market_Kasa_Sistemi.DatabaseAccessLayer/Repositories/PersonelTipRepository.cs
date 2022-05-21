using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class PersonelTipRepository : ARepository<PersonelTip>, IDisposable
    {
        public PersonelTipRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(PersonelTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<PersonelTip> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipGetById", new SqlParameter("@PersonelTipId", value)))
            {
                return await context.GetItem<PersonelTip>(cmd);
            }
        }

        public override async Task<int> Remove(PersonelTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipDelete", item.GetIdParameter()))
            {
                return await context .ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<PersonelTip>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipGetAll"))
            {
                return await context .ToList<PersonelTip>(cmd);
            }
        }

        public override async Task<int> Update(PersonelTip item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<PersonelTip>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelTipGetAll"))
            {
                return await context.ToObservableCollection<PersonelTip>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
