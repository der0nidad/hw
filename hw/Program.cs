using System;
using System.Data;
using System.Data.SQLite;

namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);    
            }
            Console.WriteLine();
            SQLiteConnection conn = new SQLiteConnection("Data Source=filename.db; Version=3;");
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            conn.Dispose();
        }
    }
}