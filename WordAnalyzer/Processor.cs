using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordAnalyzer
{
    public class Processor
    {
        public string[] ExtractWords(string text)
        {
            string extraxted = Regex.Replace(text.ToLowerInvariant(), @"[^\w\s]", " ");
            return extraxted.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
