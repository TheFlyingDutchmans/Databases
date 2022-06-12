using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Console;
using System.Diagnostics;


namespace DataBaseAssignment
{
    class Program
    {
        public static int[] startQuestion = new int[4];
        public static int[] startAnswers = new int[4];

        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do? Press enter to continue...");
            Console.ReadLine();

            int choose;

            //Switch 
            try
            {
                Console.WriteLine("Enter [1] for MySQL, [2] for NoSQL and [3] to exit");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        int entryValue = databaseSelectEntries();

                        Clear();
                        Console.WriteLine("You have selected MySQL, Enter [C] for Create, [R] for Read, [U] for Update and [D] for Delete. [E] for exit ");
                        //Console.ReadLine();
                        string answer = Console.ReadLine();

                        switch (answer.ToUpper())
                        {
                            case "C":
                                Console.WriteLine("creating " + entryValue + " entrie(s)");
                                SQLCreate create1 = new SQLCreate();
                                create1.create(entryValue);
                                break;
                            case "R":
                                Console.WriteLine("reading " + entryValue + " entrie(s)");
                                SQLRead read1 = new SQLRead();
                                read1.read(entryValue);
                                break;
                            case "U":
                                Console.WriteLine("updating " + entryValue + " entrie(s)");
                                SQLUpdate update1 = new SQLUpdate();
                                update1.update(entryValue);
                                break;
                            case "D":
                                Console.WriteLine("deleting " + entryValue + " entrie(s)");
                                SQLDelete delete1 = new SQLDelete();
                                delete1.delete(entryValue);
                                break;
                            case "E":
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Invalid entry, try again you must.");
                                Console.ReadLine();
                                break;
                        }


                        break;

                    case 2:
                        Console.WriteLine("Option 2");
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid entry, try again you must.");
                        Console.ReadLine();
                        break;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Invalid stringymajig");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            static int databaseSelectEntries()
            {
                int choice;
                Clear();
                Console.WriteLine("Enter [1] for 1 entry, [2] for 1.000 entries, [3] for 100.000 entries [4] for 1.000.000 entries");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        return 1;

                    case 2:
                        return 1000;

                    case 3:
                        return 100000;

                    case 4:
                        return 1000000;

                    default:
                        Console.WriteLine("Invalid entry, try again you must.");
                        databaseSelectEntries();
                        return 0;
                }

            }     

            #region Read
            /*static void databaseMySQLRead()
            {
                int choice;
                Clear();
                Console.WriteLine("Enter [1] for 1 entry, [2] for 1.000 entries, [3] for 100.000 entries [4] for 1.000.000 entries");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Reading one Entry");
                        databasemySQLReadOne();
                        break;

                    case 2:
                        Console.WriteLine("Reading one thousand entries");
                        databasemySQLReadOneThousand();
                        break;

                    case 3:
                        Console.WriteLine("Reading one hundread thousand entries");
                        databasemySQLReadOneHundredThousand();
                        break;

                    case 4:
                        Console.WriteLine("You mad man");
                        databasemySQLReadOneMillion();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid entry, try again you must.");
                        Console.ReadLine();
                        break;
                }
            }

            #region readamount
            static void databasemySQLReadOne()
            {
                string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataAdapter adapter;

                conn = new MySqlConnection();
                cmd = new MySqlCommand();
                adapter = new MySqlDataAdapter();

                conn.ConnectionString = ConnectionString;
                try
                {
                    Stopwatch stopw = new Stopwatch();
                    stopw.Start();

                    for (int i = 0; i < 1; i++)
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM user LIMIT 1";
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
            }

            static void databasemySQLReadOneThousand()
            {
                string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataAdapter adapter;

                conn = new MySqlConnection();
                cmd = new MySqlCommand();
                adapter = new MySqlDataAdapter();

                conn.ConnectionString = ConnectionString;
                try
                {
                    Stopwatch stopw = new Stopwatch();
                    stopw.Start();

                    for (int i = 0; i < 1; i++)
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM user LIMIT 1000";
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
            }

            static void databasemySQLReadOneHundredThousand()
            {
                string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataAdapter adapter;

                conn = new MySqlConnection();
                cmd = new MySqlCommand();
                adapter = new MySqlDataAdapter();

                conn.ConnectionString = ConnectionString;
                try
                {
                    Stopwatch stopw = new Stopwatch();
                    stopw.Start();

                    for (int i = 0; i < 1; i++)
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM user LIMIT 100000";
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
            }
            static void databasemySQLReadOneMillion()
            {
                string ConnectionString = "server=localhost;uid=root;pwd=;database=databaseassignment;";

                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataAdapter adapter;

                conn = new MySqlConnection();
                cmd = new MySqlCommand();
                adapter = new MySqlDataAdapter();

                conn.ConnectionString = ConnectionString;
                try
                {
                    Stopwatch stopw = new Stopwatch();
                    stopw.Start();

                    for (int i = 0; i < 1; i++)
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM user LIMIT 1000000";
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
            }
*/
            #endregion
        }
    }
}
