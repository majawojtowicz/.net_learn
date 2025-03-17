// See https://aka.ms/new-console-template for more information
using System;
using TextAnalyzer;

namespace TextAnalyzer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = string.Empty;
            if (args.Length > 0)
            {
                string sciezka = args[0];
                text = CzytajZPliku(sciezka);
            }
            else
            {
                Console.WriteLine("Podaj skąd chcesz wziąć tekst:");
                Console.WriteLine("1. Tekst ręcznie wpisać");
                Console.WriteLine("2. Wczytać z pliku");
                var wybor = Console.ReadLine();
                if (wybor == "1")
                {
                    Console.WriteLine("Podaj tekst:");
                    text = Console.ReadLine();
                }
                else if (wybor == "2")
                {
                    Console.WriteLine("Podaj ścieżkę do pliku:");
                    string sciezka = Console.ReadLine() ?? string.Empty;
                    text = CzytajZPliku(sciezka);
                }
                else
                {
                    Console.WriteLine("Zły wybór. Koniec działania.");
                    return;
                }
            }
            var statistics = TextAnalyzer.Analyze(text);
            WyswietlStatystyki(statistics);
        }

        private static string CzytajZPliku(string sciezka)
        {
            try
            {
                if (!File.Exists(sciezka))
                {
                    Console.WriteLine($"Plik o ścieżce '{sciezka}' nie istnieje.");
                    return string.Empty;
                }
                var content = File.ReadAllText(sciezka);
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("Plik jest pusty.");
                    return string.Empty;
                }
                return content;
            }
            catch
            {
                Console.WriteLine("Błąd podczas odczytu pliku.");
                return string.Empty;
            }
        }

        private static void WyswietlStatystyki(TextStatistics statistics)
        {
            Console.WriteLine("=== Statystyki ===");
            Console.WriteLine($"Liczba znaków (ze spacjami): {statistics.CharacterCountWithSpaces}");
            Console.WriteLine($"Liczba znaków (bez spacji): {statistics.CharacterCountWithoutSpaces}");
            Console.WriteLine($"Liczba liter: {statistics.LetterCount}");
            Console.WriteLine($"Liczba cyfr: {statistics.DigitCount}");
            Console.WriteLine($"Liczba znaków interpunkcyjnych: {statistics.PunctuationCount}");
            Console.WriteLine($"Liczba słów: {statistics.WordCount}");
            Console.WriteLine($"Liczba unikalnych słów: {statistics.UniqueWordCount}");
            Console.WriteLine($"Najczęściej występujące słowo: {statistics.MostCommonWord}");
            Console.WriteLine($"Średnia długość słowa: {statistics.AverageWordLength:F2}");
            Console.WriteLine($"Najdłuższe słowo: {statistics.LongestWord}");
            Console.WriteLine($"Najkrótsze słowo: {statistics.ShortestWord}");
            Console.WriteLine($"Liczba zdań: {statistics.SentenceCount}");
            Console.WriteLine($"Średnia liczba słów na zdanie: {statistics.AverageWordsPerSentence:F2}");
            Console.WriteLine($"Najdłuższe zdanie (pod względem liczby słów): \"{statistics.LongestSentence}\"");
        }
    }
}