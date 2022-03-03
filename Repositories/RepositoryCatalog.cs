using System;
using Catalog.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Catalog.Repositories
{
    public class RepositoryCatalog:IRepositoryCatalog
    {
        public IEnumerable<Item> GetItems()
        {
            var conn = DbConnectionSQL.getConnection();
            try
            {
                conn.Open();
                List<Item> lst = new List<Item>();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Item";
                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lst.Add(new Item 
                    { 
                        Id = reader.GetString("Id"), 
                        Name = reader.GetString("Name"), 
                        Price = reader.GetDecimal("Price"), 
                        CreateDate = reader.GetDateTime("DateTimeOffset")
                    });
                }
                return lst;
            }
            catch (System.Exception)
            {
                throw;
                return null;
            } finally{
                conn.Close();
            }
        }
        public Item GetItem(string id){
            var conn = DbConnectionSQL.getConnection();
            try
            {
                conn.Open();
                List<Item> lst = new List<Item>();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Item where Id='" +id+"'";
                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lst.Add(new Item 
                    { 
                        Id = reader.GetString("Id"), 
                        Name = reader.GetString("Name"), 
                        Price = reader.GetDecimal("Price"), 
                        CreateDate = reader.GetDateTime("DateTimeOffset")
                    });
                }
                return lst.SingleOrDefault();
            }
            catch (System.Exception)
            {
                throw;
                return null;
            } finally{
                conn.Close();
            }
        }
        public bool CreateItem (Item item)
        {
            string jsonString = JsonSerializer.Serialize(item);

            var conn = DbConnectionSQL.getConnection();
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "dbo.POC_IN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = jsonString;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }finally{
                conn.Close();
            }
            return false;
        }
        public bool UpdateItem (Item item)
        {
            string jsonString = JsonSerializer.Serialize(item);

            var conn = DbConnectionSQL.getConnection();
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "dbo.POC_UP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = jsonString;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }finally{
                conn.Close();
            }
            return false;
        }
        public bool DeleteItem (string id)
        {
            string jsonString = JsonSerializer.Serialize(id);

            var conn = DbConnectionSQL.getConnection();
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "dbo.POC_DEL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@json", SqlDbType.NVarChar).Value = jsonString;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }finally{
                conn.Close();
            }
            return false;
        }
    }
}