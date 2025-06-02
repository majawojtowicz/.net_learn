using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalyzer
{
    public class CounterW
    {
        private readonly ConcurrentDictionary<string, int> _Freq = new(StringComparer.OrdinalIgnoreCase);

        public void Process(string[] texts, Processor processor)
        {
            Parallel.ForEach(texts, text =>
            {
                var words = processor.ExtractWords(text);
                foreach (var word in words)
                {
                    _Freq.AddOrUpdate(word, 1, (_, current) => current + 1);

                }
            });
        }
        public IEnumerable<KeyValuePair<string,int>> GetWords(int count) 
        {
            return _Freq.OrderByDescending(k=>k.Value).Take(count);
        }
    }
}
