using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Library : IBookOperations
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public ListAvailableBooks 
        {
        
        }

        public bool BorrowBook(int bookId, string borrowerName)
        {
        var book = Book.book;
        if (book == null)
        {
            Console.WriteLine("Nie ma w bibliotece");
            return false;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine("Wypozyczone");
            return false;
        }

        book.IsAvailable = false;
        Console.WriteLine("Ta ksiazka wlasnie wypozyczona przez " + borrowerName);
        return 0;
        }

        public bool ReturnBook(int bookId)
        {
        var book = Book.book;
        if (book == null)
        {
            Console.WriteLine("Nie ma w bibliotece");
            return false;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine("Wypozyczone");
            return false;
        }

        book.IsAvailable = true;
        Console.WriteLine("Ta ksiazka wlasnie zwrocona przez " + borrowerName);
        return 0;
    }
    }
}
