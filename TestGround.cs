using System;
using System.Threading;
using System.Diagnostics;

namespace TestGround
{
  public static class Program
  {
    public static void Main()
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();

      while (true)
      {
        Console.WriteLine($"Time Elapsed: {watch.Elapsed}");
      } 


      Console.ReadLine();
    }

    private static void TimerCallback(object o)
    {
      
    }
  }
}