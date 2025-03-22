// See https://aka.ms/new-console-template for more information
using KalkulatorApp;
class Program
{
    
    static void Main(string[] args)
    {
        var service = new CalculatorService();
        service.Initialize();
    }
}
