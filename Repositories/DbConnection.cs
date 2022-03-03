using System;
using MySql.Data.MySqlClient;  


namespace Catalog.Repositories
{
    public class DbConnection
    {
        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = null;
            var sb = new MySqlConnectionStringBuilder
            {
                Server = "159.223.79.247",
                UserID = "root",
                Password = "quanla02@ciuz",
                Port = 3306,
                Database = "Catalog"
            };
            try
            {
                Console.WriteLine(sb.ConnectionString);
                return new MySqlConnection(sb.ConnectionString);
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return null;
            }

        }
    }
}