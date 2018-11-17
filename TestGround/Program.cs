using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestGround
{
    public static class Program
    {
        public static Stopwatch battleWatch = new Stopwatch();

        public static void Main()
        {
            battleWatch.Start();

            bool isValid;

            do
            {
                isValid = false;
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);

                switch(input.Key)
                {
                    case ConsoleKey.A:
                        {
                            Console.WriteLine($"Time elapsed in ms : {battleWatch.ElapsedMilliseconds}");
                            break;
                        }

                    case ConsoleKey.Q:
                        {
                            isValid = true;
                            break;
                        }
                }

            } while (!isValid);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {

        }
    }
}
