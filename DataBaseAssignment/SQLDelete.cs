using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataBaseAssignment
{
    class SQLDelete
    {
        public SQLDelete() { }

        public void delete(int entries)
        {
            string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataAdapter adapter;

            conn = new MySqlConnection();
            
            int entryValue = entries;
            conn.ConnectionString = ConnectionString;
            try
            {
                Stopwatch stopw = new Stopwatch();
                stopw.Start();
                conn.Open();

             
                    cmd = new MySqlCommand();
                    adapter = new MySqlDataAdapter();

                    cmd.Connection = conn;

                    //cmd.CommandText = "DELETE TOP " + "(" + entryValue + ") FROM user";
                    cmd.CommandText = "DELETE FROM user LIMIT @limit";
                    //cmd.CommandText = "WITH CTE AS(SELECT TOP(" + i + ") t.* FROM user AS t" +
                    //    "WHERE  t.userID = " + i + " DELETE FROM CTE";
                    cmd.Parameters.Add("@limit", MySqlDbType.Int64);
                    cmd.Parameters["@limit"].Value = entryValue;

                    Console.WriteLine("Delete");

                    cmd.ExecuteNonQuery();

                conn.Close();

                stopw.Stop();
                Console.WriteLine(" Time elapsed: {0} ", stopw.Elapsed);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}