using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DXPivotGrid.Infrastructure
{
    public class DataGateway
    {
        private readonly string _connectString;

        public DataGateway(string server, string database)
        {
            _connectString = GetConnectionString(server, database);

        }

        public DataSet GetDataset(string resultTableName, string executionContext, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var cmd = new SqlCommand(executionContext, conn);
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();

                var adapter = new SqlDataAdapter {SelectCommand = cmd};
                var ds = new DataSet();

                adapter.Fill(ds, resultTableName);

                return ds;
            }
        }

        private string GetConnectionString(string server, string database)
        {
            var builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = server;
            builder["Initial Catalog"] = database;
            builder["Integrated Security"] = "SSPI";
            builder["MultipleActiveResultSets"] = true;

            return builder.ConnectionString;
        }

    }
}