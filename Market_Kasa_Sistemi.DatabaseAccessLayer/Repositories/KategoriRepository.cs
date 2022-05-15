using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class KategoriRepository : ARepository<Kategori>, IDisposable
    {
        public KategoriRepository(DBContext context) : base(context) {}

        public override object Add(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriAdd", item.GetInsertParameters()))
            {
                return context.ExecuteScalar(cmd);
            }
        }

        public override Kategori GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriGetById", new SqlParameter("@KategoriId", value)))
            {
                return context.GetItem<Kategori>(cmd);
            }
        }

        public override int Remove(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriDelete", item.GetIdParameter()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }

        public override List<Kategori> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriGetAll"))
            {
                return context.ToList<Kategori>(cmd);
            }
        }

        public override int Update(Kategori item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPKategoriUpdate", item.GetUpdateParameters()))
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
