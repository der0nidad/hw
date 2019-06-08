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
            Environment.Exit(0);
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
//                CREATE TABLE IF NOT EXISTS some_table (id INTEGER PRIMARY KEY AUTOINCREMENT, ...);
                SQLiteCommand cmd = conn.CreateCommand();
                string sql_command = "DROP TABLE IF EXISTS person;"
                                     + "CREATE TABLE person("
                                     + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                                     + "first_name TEXT, "
                                     + "last_name TEXT, "
                                     + "sex INTEGER, "
                                     + "birth_date INTEGER);"
                                     + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                                     + "VALUES ('John', 'Doe', 0, strftime('%s', '1979-12-10'));"
                                     + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                                     + "VALUES ('Vanessa', 'Maison', 1, strftime('%s', '1977-12-10'));"
                                     + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                                     + "VALUES ('Ivan', 'Vasiliev', 0, strftime('%s', '1987-01-06'));"
                                     + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                                     + "VALUES ('Kevin', 'Drago', 0, strftime('%s', '1991-06-11'));"
                                     + "INSERT INTO person(first_name, last_name, sex, birth_date) "
                                     + "VALUES ('Angel', 'Vasco', 1, strftime('%s', '1987-10-09'));";
                cmd.CommandText = sql_command;
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