using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class PersonelRepository : ARepository<Personel>, IDisposable
    {
        public PersonelRepository(DBContext context) : base(context) { }

        public override object Add(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelAdd", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override Personel GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelGetById", new SqlParameter("@PersonelId", value)))
            {
                return context.GetItem<Personel>(cmd);
            }
        }

        public override int Remove(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelDelete", item.GetIdParameter()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override List<Personel> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelGetAll"))
            {
                return context.ToList<Personel>(cmd);
            }
        }

        public override int Update(Personel item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPPersonelUpdate", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
