using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.ModelLayer;
using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public class SatisRepository : ARepository<Satis>, IDisposable
    {
        public SatisRepository(DBContext context) : base(context) { }

        public override async Task<object> Add(Satis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisAdd", item.GetInsertParameters()))
            {
                return await context.ExecuteScalar(cmd);
            }
        }

        public override async Task<Satis> GetItem(object value)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisGetById", new SqlParameter("@SatisId", value)))
            {
                return await context.GetItem<Satis>(cmd);
            }
        }

        public override async Task<int> Remove(Satis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisDelete", item.GetIdParameter()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<List<Satis>> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisGetAll"))
            {
                return await context.ToList<Satis>(cmd);
            }
        }

        public async Task<List<Satis>> AllSatisByFisId(int FisId)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisGetAllByFisId", new SqlParameter("FisId", FisId)))
            {
                return await context.ToList<Satis>(cmd);
            }
        }

        public async Task<ObservableCollection<Satis>> AllSatisByFisIdObservable(int FisId)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisGetAllByFisId", new SqlParameter("FisId", FisId)))
            {
                return await context.ToObservableCollection<Satis>(cmd);
            }
        }

        public async Task<List<ZRaporu>> GetZReport()
        {
            using (SqlCommand cmd = context.CreateCommand("SELECT * FROM VwZReport", System.Data.CommandType.Text))
            {
                return await context.ToList<ZRaporu>(cmd);
            }
        }

        public async Task<ObservableCollection<ZRaporu>> GetZReportObservable()
        {
            using (SqlCommand cmd = context.CreateCommand("SELECT * FROM VwZReport", System.Data.CommandType.Text))
            {
                return await context.ToObservableCollection<ZRaporu>(cmd);
            }
        }

        public override async Task<int> Update(Satis item)
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisUpdate", item.GetUpdateParameters()))
            {
                return await context.ExecuteNonQuery(cmd);
            }
        }

        public override async Task<ObservableCollection<Satis>> ToObservableCollection()
        {
            using (SqlCommand cmd = context.CreateCommand("SPSatisGetAll"))
            {
                return await context.ToObservableCollection<Satis>(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
