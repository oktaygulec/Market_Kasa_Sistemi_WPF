using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Market_Kasa_Sistemi.Models
{
    public class Kategori : IModel
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }

        public SqlParameter GetIdParameter()
        {
            return new SqlParameter("KategoriId", this.Id);
        }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter> { 
                new SqlParameter("KategoriAd", this.KategoriAd)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = GetInsertParameters();
            parameters.Add(GetIdParameter());
            return parameters;
        }

        public void ReadItem(SqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["KategoriId"]);
            this.KategoriAd = reader["KategoriAd"].ToString();
        }
    }
}
