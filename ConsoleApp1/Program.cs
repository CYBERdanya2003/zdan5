using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string[] text = new string[]
        {
            "Послушайте!",
            "Ведь, если звезды зажигают —",
            "значит — это кому-нибудь нужно?",
            "Значит — кто-то хочет, чтобы они были?",
            "Значит — кто-то называет эти плево́чки жемчужиной?"
        };

        Dictionary<string, int> wordCounts = WordCounter.CountWords(text);

        foreach (var entry in wordCounts)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

public class WordCounter
{
    public static Dictionary<string, int> CountWords(string[] text)
    {
        return text
            .SelectMany(line => line.Split(new[] { ' ', ',', '.', ';', '!', '?', '—', '-', ':' }, StringSplitOptions.RemoveEmptyEntries))
            .GroupBy(word => word.ToLower())
            .ToDictionary(group => group.Key, group => group.Count())
            .OrderBy(pair => pair.Key)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
