using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protoype
{
    class Program
    {
        static void Main()
        {
            var reportTemplate = new DocumentTemplate("Raport Firmowy", "Strona 1 z 1");
            var original = new Document("Raport 2025", "Zawartość raportu...", reportTemplate);

            var copy = (Document)original.Clone();
            copy.Title = "Kopia Raportu";
            copy.Template.Footer = "Strona 1 z 2";

            Console.WriteLine("ORYGINAŁ:");
            original.Display();

            Console.WriteLine("\nKOPIA:");
            copy.Display();
        }
    }

}

