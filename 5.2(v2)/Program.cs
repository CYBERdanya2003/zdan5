using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var fitnessCenterDB = new FitnessCenterDatabase();
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 1, Year = 2021, Month = 5, Duration = 13 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 2, Year = 2021, Month = 6, Duration = 12 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 1, Year = 2021, Month = 12, Duration = 16 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 2, Year = 2021, Month = 4, Duration = 20 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 1, Year = 2022, Month = 1, Duration = 12 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 2, Year = 2022, Month = 2, Duration = 15 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 1, Year = 2023, Month = 1, Duration = 10 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 2, Year = 2023, Month = 2, Duration = 20 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 1, Year = 2023, Month = 3, Duration = 11 });
        fitnessCenterDB.AddRecord(new FitnessCenterDatabase.Record { ClientID = 2, Year = 2023, Month = 4, Duration = 20 });

        fitnessCenterDB.PrintTotalDurationPerYear();

        Console.ReadLine();
    }
}
public class FitnessCenterDatabase
{
    public struct Record
    {
        public int ClientID;
        public int Year;
        public int Month;
        public int Duration;
    }

    private List<Record> database;
    public FitnessCenterDatabase()
    {
        database = new List<Record>();
    }

    public void AddRecord(Record record)
    {
        database.Add(record);
    }

    public void PrintTotalDurationPerYear()
    {
        var yearlyTotals = database
            .GroupBy(r => r.Year)
            .Select(g => new
            {
                Year = g.Key,
                TotalDuration = g.Sum(r => r.Duration)
            })
            .OrderBy(g => g.Year);
        foreach (var item in yearlyTotals)
        {
            Console.WriteLine($"Год: {item.Year}, Общая продолжительность: {item.TotalDuration} часов");
        }
    }
}

