using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_04
{

    /// Задача - дорабатываем будильник
    /// необходимо написать метод, который позволит считать, сколько времени осталось до того, как зазвонит будильник


    class Program
    {
        private static IEnumerable<DateTime> AlarmClockTimer(DateTime wakeUp)
        {
            var count = (wakeUp - DateTime.Now).Seconds;
            List<DateTime> buf = new List<DateTime>();
            while(count >= 0)
            {
                var time = wakeUp;
                buf.Add(time.AddSeconds(-count));
                count--;
            }
            return buf;
        }

        static void Main(string[] args)
        {
            var wakeUp = DateTime.Now.AddSeconds(10);
            foreach (DateTime value in AlarmClockTimer(wakeUp))
            {

                Console.WriteLine((wakeUp - value).ToString(@"dd\.hh\:mm\:ss"));
                Thread.Sleep(1000);
            }
            Console.Beep();
            Console.Read();
        }
    }
}
