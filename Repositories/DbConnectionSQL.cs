using System;
using System.Data;
using System.Data.SqlClient; 

namespace Catalog.Repositories
{
    public class DbConnectionSQL
    {
        public static SqlConnection getConnection(){
            try
            {
                string sqlconnectStr = "Data Source=basil;Initial Catalog=CATALOG;User ID=sa;Password=Quoc123!@#";
                return new SqlConnection(sqlconnectStr);
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
                return null;
            }
            return null;
        }
    }
}