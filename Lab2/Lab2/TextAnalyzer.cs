using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    public static class TextAnalyzer
    {
        public static TextStatistics Analyze(string text)
        {
            var statistics = new TextStatistics();
            if (text==null)
            {
                return statistics;
            }
            statistics.CharacterCountWithSpaces = text.Length;
            statistics.CharacterCountWithoutSpaces = text.Replace(" ", "").Length;
            int letterCount = 0;
            int digitCount = 0;
            int punctuationCount = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                { letterCount++; }
                else if (char.IsDigit(c))
                { digitCount++; }
                else if (char.IsPunctuation(c)) 
                { punctuationCount++; }

            }
            statistics.LetterCount = letterCount;
            statistics.DigitCount = digitCount;
            statistics.PunctuationCount = punctuationCount;
            var slowa = GetWords(text);
            statistics.WordCount = slowa.Count;
            var uniqueWords = new HashSet<string>(slowa, StringComparer.OrdinalIgnoreCase);
            statistics.UniqueWordCount = uniqueWords.Count;
            statistics.MostCommonWord = MostCommon(slowa);
            statistics.AverageWordLength = slowa.Count > 0 ? slowa.Average(w => w.Length) : 0.0;
            if (slowa.Count > 0)
            {
                statistics.LongestWord = slowa.OrderByDescending(w => w.Length).First();
                statistics.ShortestWord = slowa.OrderBy(w => w.Length).First();
            }
            var sentences = GetSentences(text);
            statistics.SentenceCount = sentences.Count;
            if (sentences.Count > 0)
            {
                int totalWordsInSentences = 0;
                foreach (var sentence in sentences)
                {
                    var wordsInSentence = GetWords(sentence);
                    totalWordsInSentences += wordsInSentence.Count;
                }
                statistics.AverageWordsPerSentence = (double)totalWordsInSentences / sentences.Count;
            }
            if (sentences.Count > 0)
            {
                int maxWords = 0;
                string longestSentence = string.Empty;
                foreach (var sentence in sentences)
                {
                    var wordsInSentence = GetWords(sentence);
                    if (wordsInSentence.Count > maxWords)
                    {
                        maxWords = wordsInSentence.Count;
                        longestSentence = sentence;
                    }
                }
                statistics.LongestSentence = longestSentence.Trim();
            }
            return statistics;
        }

        private static List<string> GetWords(string text)
        {
            var matches = Regex.Matches(text, @"[A-Za-z0-9]+");
            return matches.Select(m => m.Value).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }

        private static List<string> GetSentences(string text)
        {
            var sentences = Regex.Split(text, @"[.!?]+").Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            return sentences;
        }

        private static string MostCommon(List<string> words)
        {
            if (words == null || words.Count == 0) return string.Empty;
            var freq = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var w in words)
            {
                if (!freq.ContainsKey(w)) freq[w] = 1;
                else freq[w]++;
            }
            int maxCount = freq.Values.Max();
            return freq.First(x => x.Value == maxCount).Key;
        }
    }
}
