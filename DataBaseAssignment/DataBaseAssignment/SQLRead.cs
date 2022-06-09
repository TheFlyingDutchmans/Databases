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

            int entryValue = entries;
            conn.ConnectionString = ConnectionString;
            try
            {


                Stopwatch stopw = new Stopwatch();
                stopw.Start();
                conn.Open();

                for (int i = 0; i < entryValue; i++)
                {
                    cmd = new MySqlCommand();
                    adapter = new MySqlDataAdapter();

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO user (FirstName, LastName) VALUES (@firstName, @LastName);";
                    //int userID = i;
                    string firstName = Faker.Name.First();
                    string lastName = Faker.Name.Last();

                    cmd.Parameters.Add("@firstName", MySqlDbType.String);
                    cmd.Parameters["@firstName"].Value = firstName;

                    cmd.Parameters.Add("@lastName", MySqlDbType.String);
                    cmd.Parameters["@lastName"].Value = lastName;

                    cmd.ExecuteNonQuery();
                }
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