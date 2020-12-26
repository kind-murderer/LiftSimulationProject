using System;
using System.Diagnostics;

namespace Services.Services
{
    public class CounterService
    {
        public static int NumberOfTrips { get; set; }
        public static int NumberOfBlankTrips { get; set; }
        public static int NumberOfCreatedPassangers { get; set; }
        public static int NumberOfDeliveredPassangers { get; set; }
        public static int TotalCarriedWeight { get; set; }

        //private TimeSpan ts;
        static Stopwatch stopWatch = new Stopwatch();

        public static void StartCountingTime()
        {
            stopWatch.Start();
        }
        public static void StopCountingTime()
        {
            stopWatch.Stop();
        }

        public static void WriteSomeStatisticToConsole()
        {
            TimeSpan time = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Время проведшее с начала работы системы: {0:00}:{1:00}:{2:00}.", time.Hours, time.Minutes, time.Seconds));
            Console.WriteLine(String.Format("Количество перевезенных людей за сеанс работы: {0}.", NumberOfDeliveredPassangers));
        }

    }
}
