// See https://aka.ms/new-console-template for more information
using MyLibrary;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using MyServices;

class Program
{
    static void Main()
    {
        // Konfiguracja kontenera DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerService, ConsoleLogger>()
            .BuildServiceProvider();

        // Uzyskanie instancji loggera
        var logger = serviceProvider.GetService<ILoggerService>();
        logger.Log("Aplikacja uruchomiona.");

        // Przykładowe użycie kalkulatora
        Calculator calculator = new Calculator();
        int sum = calculator.Add(10, 15);
        logger.Log($"Wynik dodawania: {sum}");

       
        int suma = calculator.Add(20, 20);
        int roznica = calculator.Subtract(49, 20);
        var result = new { Operation = "Add", A = 20, B = 20, Result = suma };

        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine(jsonResult);
    }
}