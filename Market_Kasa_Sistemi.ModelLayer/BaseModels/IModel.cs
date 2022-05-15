using System.Collections.Generic;
using System.Data.SqlClient;

namespace Market_Kasa_Sistemi.Models
{
    public interface IModel
    {
        int Id { get; set; }

        void ReadItem(SqlDataReader reader);

        List<SqlParameter> GetInsertParameters();
        List<SqlParameter> GetUpdateParameters();
        SqlParameter GetIdParameter();
    }
}
