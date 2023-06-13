using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<DateTime> visits = new List<DateTime>
        {
            new DateTime(2021, 12, 15, 20, 2, 15),
            new DateTime(2022, 3, 15, 12, 30, 0),
            new DateTime(2023, 6, 1, 11, 0, 0),
            new DateTime(2024, 3, 15, 10, 30, 0)
        };

        VisitAnalyzer.CalculateTotalVisitingTimePerYear(visits);
    }
}

public class VisitAnalyzer
{
    public static void CalculateTotalVisitingTimePerYear(List<DateTime> visits)
    {
        visits.GroupBy(visit => visit.Year)
            .OrderBy(group => group.Key)
            .Select(group => new { Year = group.Key, TotalVisitingTime = group.Sum(visit => visit.TimeOfDay.Ticks) })
            .ToList()
            .ForEach(result => Console.WriteLine($"{result.Year}: {TimeSpan.FromTicks(result.TotalVisitingTime):hh\\:mm\\:ss}"));
    }
}


