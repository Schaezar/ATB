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
        public enum States { INIT, CHOOSE_ACTION, IDLE, PROCESS_ACTION }

        public static Stopwatch battleWatch = new Stopwatch();
        public static bool isDead = false;
        public static long actionTimeStamp;

        public static void Main()
        {
            States currState = States.INIT;

            battleWatch.Start();

            do
            {
                switch(currState)
                {
                    case States.INIT:
                        {
                            Console.WriteLine("Currently in the INIT state");
                            if (battleWatch.ElapsedMilliseconds >= 5000)
                                currState = States.CHOOSE_ACTION;
                            break;
                        }

                    case States.CHOOSE_ACTION:
                        {
                            Console.WriteLine("Currently in the CHOOSE_ACTION state");
                            ParseCommand();
                            currState = States.IDLE;
                            break;
                        }

                    case States.IDLE:
                        {
                            Console.WriteLine($"Wait a bit, currently {battleWatch.ElapsedMilliseconds} / {actionTimeStamp}");
                            if (battleWatch.ElapsedMilliseconds >= actionTimeStamp)
                                currState = States.PROCESS_ACTION;
                            break;
                        }

                    case States.PROCESS_ACTION:
                        {
                            Console.WriteLine($"You cast a spell...... AND IT FIZZLES... OMG!!!");
                            currState = States.INIT;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            } while (!isDead);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void ParseCommand()
        {
            bool isValid = true;

            do
            {
                isValid = true;
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        {
                            Console.WriteLine($"Hello from the CHOOSE_ACTION state : {battleWatch.ElapsedMilliseconds}");

                            isValid = false;
                            break;
                        }

                    case ConsoleKey.S:
                        {
                            Console.WriteLine($"You have decided to use a spell, it will take effect at : {battleWatch.ElapsedMilliseconds + 7500}");
                            actionTimeStamp = battleWatch.ElapsedMilliseconds + 7500;
                            isValid = true;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            } while (!isValid);
        }
    }
}
