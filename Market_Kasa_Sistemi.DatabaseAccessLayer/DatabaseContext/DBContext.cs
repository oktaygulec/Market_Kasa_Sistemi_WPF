using Market_Kasa_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext
{
    public class DBContext : IDisposable
    {
        public SqlConnection Connection { get; private set; }

        public DBContext()
        {
            Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MarketDB.mdf;Integrated Security=True");
        }

        public async Task OpenConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    await Connection.OpenAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlCommand CreateCommand(string commandText,
                                        CommandType commandType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = Connection.CreateCommand();

            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            return cmd;
        }

        public SqlCommand CreateCommand(string commandText,
                                        SqlParameter parameter,
                                        CommandType commandType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = CreateCommand(commandText, commandType);
            cmd.Parameters.Add(parameter);

            return cmd;
        }

        public SqlCommand CreateCommand(string commandText,
                                        List<SqlParameter> parameters,
                                        CommandType commandType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = CreateCommand(commandText, commandType);

            cmd.Parameters.AddRange(parameters.ToArray());

            return cmd;
        }

        public async Task<object> ExecuteScalar(SqlCommand cmd)
        {
            await OpenConnection();
            object id = await cmd.ExecuteScalarAsync();
            CloseConnection();

            return id;
        }

        public async Task<int> ExecuteNonQuery(SqlCommand cmd)
        {
            await OpenConnection();
            int executedRows = await cmd.ExecuteNonQueryAsync();
            CloseConnection();

            return executedRows;
        }

        public async Task<T> GetItem<T> (SqlCommand cmd) where T : IModel
        {
            T item = Activator.CreateInstance<T>();
            
            await OpenConnection();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows && await reader.ReadAsync())
            {
                item.ReadItem(reader);
            }

            CloseConnection();
            return item;
        }

        public async Task<List<T>> ToList<T>(SqlCommand cmd) where T : IModel
        {
            List<T> items = new List<T>();

            await OpenConnection ();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                T item = Activator.CreateInstance<T>();

                if (reader.HasRows)
                {
                    item.ReadItem(reader);
                    items.Add(item);
                }
            }

            CloseConnection();
            return items;
        }

        public async Task<ObservableCollection<T>> ToObservableCollection<T>(SqlCommand cmd) where T : IModel
        {
            ObservableCollection<T> items = new ObservableCollection<T>();

            await OpenConnection ();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                T item = Activator.CreateInstance<T>();

                if (reader.HasRows)
                {
                    item.ReadItem(reader);
                    items.Add(item);
                }
            }

            CloseConnection();
            return items;
        }

        public void Dispose()
        {
            Connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
