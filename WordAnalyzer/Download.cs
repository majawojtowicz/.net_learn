using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace WordAnalyzer
{
    public class Download
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string[]> DownloadTextAsync(string[] links)
        {
            var tasks = links.Select(link => DownloadAsync(link));
            return await Task.WhenAll(tasks);
        }

        private async Task<string> DownloadAsync(string link)
        {
            try
            {
                return await _httpClient.GetStringAsync(link);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
