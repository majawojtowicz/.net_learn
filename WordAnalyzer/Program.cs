using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WordAnalyzer;

public class Program
{
    static readonly string[] links = new[]
    {
        "https://www.gutenberg.org/files/84/84-0.txt",
        "https://www.gutenberg.org/files/11/11-0.txt",
        "https://www.gutenberg.org/files/1661/1661-0.txt",
        "https://www.gutenberg.org/files/2701/2701-0.txt"
    };

    static async Task Main()
    {
        var downloader = new Download();
        var processor = new Processor();
        var counter = new CounterW();
        var report = new Report();

        var downloadTimer = Stopwatch.StartNew();
        var texts = await downloader.DownloadTextAsync(links);
        downloadTimer.Stop();

        var processTimer = Stopwatch.StartNew();
        counter.Process(texts, processor);
        processTimer.Stop();
        report.Print(counter, downloadTimer.Elapsed, processTimer.Elapsed);
    }
}