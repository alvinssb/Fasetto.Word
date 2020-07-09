using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();
            Method2();
            Console.ReadKey();
        }

        public static void Method1()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Delay(100);
                    Console.WriteLine(" Method 1");
                }
            });
        }


        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Task.Delay(100);
                Console.WriteLine(" Method 2");
            }
        }
    }
}
