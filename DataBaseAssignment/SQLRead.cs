using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataBaseAssignment
{
    class SQLRead
    {
        public SQLRead(){}

        public void read(int entries)
        {
            string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataAdapter adapter;

            conn = new MySqlConnection();
            cmd = new MySqlCommand();
            adapter = new MySqlDataAdapter();

            int entryValue = entries;
            conn.ConnectionString = ConnectionString;
            try
            {
                Stopwatch stopw = new Stopwatch();
                stopw.Start();

                for (int i = 0; i < 1; i++)
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM user LIMIT " + entryValue;
                    adapter.SelectCommand = cmd;
                    using MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                    }

                    stopw.Stop();
                    Console.WriteLine(" Time elapsed: {0} ", stopw.Elapsed);
                    conn.Close();

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //code
        }
        
    }
}