using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToblickaDat
{
    internal class Program
    {
        static void Main() // основная часть
        {
            var startTimes = new List<DateTime>
        {
            new DateTime(2007, 10, 10, 9, 0, 0), // начало дня
            new DateTime(2007, 10, 10, 9, 30, 0),
            new DateTime(2007, 10, 10, 10, 0, 0),
            new DateTime(2007, 10, 10, 10, 30, 0),
            new DateTime(2007, 10, 10, 11, 0, 0),
            new DateTime(2007, 10, 10, 11, 30, 0),
            new DateTime(2007, 10, 10, 12, 0, 0),
            new DateTime(2007, 10, 10, 12, 30, 0),
            new DateTime(2007, 10, 10, 13, 0, 0),
            new DateTime(2007, 10, 10, 13, 30, 0),
            new DateTime(2007, 10, 10, 14, 0, 0)  // последняя консультация
        };
            var durations = new List<TimeSpan> 
        {
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
            TimeSpan.FromMinutes(30),
        };
            TimeSpan consultationTime = TimeSpan.FromMinutes(30);
            DateTime beginWorkingTime = new DateTime(2007, 10, 10, 9, 0, 0);
            DateTime endWorkingTime = new DateTime(2007, 10, 10, 14, 0, 0);
            string[] periryv = FreeTime(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);
            foreach (var vrema in periryv)
            {
                Console.WriteLine(vrema);
            }
        }
        static string[] FreeTime(List<DateTime> startTimes, List<TimeSpan> durations, TimeSpan consultationTime, DateTime beginWorkingTime, DateTime endWorkingTime) // то что находит свободное время в графике
        {
            List<string> okna = new List<string>(); // Список для хранения окон в расписание
            List<(DateTime start, DateTime end)> zaneto = new List<(DateTime, DateTime)>();
            for (int i = 0; i < startTimes.Count; i++)
            {
                zaneto.Add((startTimes[i], startTimes[i].Add(durations[i])));
            }
            zaneto.Add((beginWorkingTime, beginWorkingTime));
            zaneto.Add((endWorkingTime, endWorkingTime));
            zaneto = zaneto.OrderBy(time => time.start).ToList();
            for (int i = 0; i <= startTimes.Count; i++) // нахождение кол-ва окон
            {
                DateTime startyk = zaneto[i].start;
                DateTime endyk = zaneto[i].end;
                TimeSpan svobno = startyk - endyk;
                if (svobno >= consultationTime) // структурирование окон
                {
                    DateTime Nachalo = endyk;
                    DateTime Konec = startyk.Add(consultationTime);
                    while(Konec <= Nachalo)
                    {
                        okna.Add($"{Nachalo:hh:mm}-{Konec:hh:mm}");
                        startyk = Konec;
                        endyk = Nachalo.Add(consultationTime);
                    }
                }
            }

            return okna.ToArray(); // получение массива
        }
    }
}
