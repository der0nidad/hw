using System;


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
            Logger lg = new Logger();
            lg.Init();
            lg.Log("my first msg");
            Console.WriteLine("we good");
        }
    }
}