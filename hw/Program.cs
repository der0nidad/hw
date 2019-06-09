using System;


namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=filename.db; Version=3;";
            if (args.Length == 2)
            {
                if (args[0] == "-conn-string")
                {
                    connString = args[1];
                }
            }

            Logger lg = new Logger();
            lg.Init(connString);
            lg.Log("раз");
            lg.Log("два");
            lg.Log("три");
            Console.WriteLine("we good");
        }
    }
}