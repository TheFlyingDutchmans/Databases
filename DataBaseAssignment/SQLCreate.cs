using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataBaseAssignment
{
    class SQLCreate
    {

        public void create(int entries)
        {
            {
                string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";
                var rand = new Random();
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

                        // Create query 1
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO user (firstName, lastName) VALUES (@firstName, @lastName) ");

                        // Bind parameters to query 1
                        cmd1.Parameters.AddWithValue("@firstName", "John");
                        cmd1.Parameters.AddWithValue("@lastName", "Doe");

                        // Idk what this does, can't test it :D
                        // cmd1.CommandType = CommandType.Text;

                        // Execute query 1
                        int userId = Convert.ToInt32(cmd1.ExecuteScalar());

                        // Create query 2
                        MySqlCommand cmd2 = new MySqlCommand("INSERT INTO profile (userId, profileName) VALUES (@userId, @profileName)");

                        // Bind parameters to query 2
                        cmd2.Parameters.AddWithValue("@userId", userId);
                        cmd2.Parameters.AddWithValue("@profileName", "John Doe");
                        
                        /*// Idk what this does, can't test it :D
                        cmd2.CommandType = CommandType.Text;*/

                        // Execute query 2
                        cmd2.ExecuteNonQuery();

                        //int userID = i;
                        string firstName = Faker.Name.First();
                        string lastName = Faker.Name.Last();
                        string profileName = Faker.Name.First();

                        cmd.Parameters.Add("@firstName", MySqlDbType.String);
                        cmd.Parameters["@firstName"].Value = firstName;

                        cmd.Parameters.Add("@lastName", MySqlDbType.String);
                        cmd.Parameters["@lastName"].Value = lastName;

                        cmd.Parameters.Add("@profileName", MySqlDbType.String);
                        cmd.Parameters["@profileName"].Value = profileName;

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
}






/*
//cmd.CommandText = "CREATE TRIGGER updateTable ON user AFTER INSERT AS BEGIN IF @@ROWCOUNT = 0 RETURN SET NOCOUNT ON; UPDATE profile SET userID FROM user JOIN user profile.userId = user.userID END";
cmd.CommandText = "INSERT INTO user (FirstName, LastName) VALUES (@firstName, @LastName);";
int lastInsertedID = (int)cmd.ExecuteScalar();
cmd.CommandText = "INSERT INTO profile (userID, profileName) VALUES (" + lastInsertedID + "@profileName);";


//cmd.CommandText = "INSERT INTO user (FirstName, LastName) VALUES (@firstName, @LastName);";
//cmd.CommandText = "INSERT INTO profile (profileName) VALUES (@profileName) (SELECT userID FROM user);";

//cmd.CommandText = "INSERT INTO user (firstName, lastName) OUTPUT inserted.userID INTO profile VALUES (userID);";


//cmd.CommandText = "INSERT INTO user(firstName, lastName) OUTPUT inserted.userID, inserted.firstName INTO GeekTable2 VALUES(@firstName, @lastName), (inserted.userID, inserted.firstName)";
//cmd.CommandText = "INSERT INTO user (FirstName, LastName) VALUES (@firstName, @LastName);";
//cmd.CommandText = "INSERT INTO profile (profileID, userID, profileName) SELECT userID, firstName FROM user";*/