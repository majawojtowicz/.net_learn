using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("C# Programming", "John Doe", "12345");
            Book book2 = new Book("Design Patterns", "Gamma et al.", "67890");
            library.AddBook(book1);
            library.AddBook(book2);

            Reader reader = new Reader(1, "Alice", "alice@example.com");
            library.RegisterReader(reader);

            if (library.BorrowBook("12345", reader.Name))
            {
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Book is not available.");
            }

            // Zwrot książki
            if (library.ReturnBook("12345"))
            {
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine("Failed to return book.");
            }

            Console.WriteLine();
            Console.WriteLine("Nacisnij klawisz aby zakonczyc program");
            Console.ReadKey();
        }
    }
}
