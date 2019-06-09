using System;
using System.Data;
using System.Data.SQLite;

namespace hw
{
    public class Logger : IDisposable
    {
        private SQLiteConnection conn;

        public void Init(string connectionString = "Data Source=filename.db; Version=3;")
        {
            conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    DateTime dt = DateTime.Now;
                    SQLiteCommand cmd = conn.CreateCommand();


                    string sql_command = "DROP TABLE IF EXISTS EventLogs;"
                                         + "CREATE TABLE EventLogs("
                                         + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                                         + "CreationDateTime Datetime, "
                                         + "Message TEXT);"
                                         + "INSERT INTO EventLogs(CreationDateTime, Message) "
                                         + "VALUES (@datetime, 'Msg1');"
                        ;
                    cmd.CommandText = sql_command;
                    cmd.Parameters.AddWithValue("@datetime", dt);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Log(string message)
        {
            if (conn.State == ConnectionState.Open)
            {
                DateTime dt = DateTime.Now;
                SQLiteCommand cmd = conn.CreateCommand();
                string app_name = System.AppDomain.CurrentDomain.FriendlyName;
                    

                string sql_command = "DROP TABLE IF EXISTS EventLogs;"
                                     + "CREATE TABLE EventLogs("
                                     + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                                     + "CreationDateTime Datetime, "
                                     + "Message TEXT,"
                                     + "ApplicationName TEXT,"
                                     + "Server TEXT);"
                                     + "INSERT INTO EventLogs(CreationDateTime, Message, ApplicationName, Server) "
                                     + "VALUES (@datetime, @msg, @application_name, @host_name);"
                    ;

                cmd.CommandText = sql_command;
                cmd.Parameters.AddWithValue("@datetime", dt);
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.Parameters.AddWithValue("@application_name",app_name);
                cmd.Parameters.AddWithValue("@host_name", System.Environment.MachineName);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            conn.Dispose();
        }
    }
}