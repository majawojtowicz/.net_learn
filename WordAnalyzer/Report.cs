using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace WordAnalyzer
{
    public class Report
    {
        public void Print(CounterW counter, TimeSpan downloadTime, TimeSpan processTime)
        {
            Console.WriteLine("Najczęstsze słowa:");
            int rank = 1;
            foreach (var kv in counter.GetWords(10))
            {
                Console.WriteLine($"{rank++}. {kv.Key}: {kv.Value}");
            }

            Console.WriteLine($"\nCzas pobierania: {downloadTime.TotalSeconds:F2} sekundy");
            Console.WriteLine($"Czas przetwarzania: {processTime.TotalSeconds:F2} sekundy");
        }
    }
}

