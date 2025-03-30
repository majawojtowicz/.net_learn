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

        public List<Book> ListAvailableBooks()
        {
            return books.Where(b => b.IsAvailable).ToList();
        }

        private List<Reader> readers = new List<Reader>();
        public void RegisterReader(Reader reader)
        {
            if(!readers.Any(r => r.Id == reader.Id))
            {
                readers.Add(reader);
            }
        }

        public bool BorrowBook(string bookId, string borrowerName)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException("Nie znalezion książki o tym ID.");
                
            }
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("wypożyczona.");
            }

            book.IsAvailable = false;
            Console.WriteLine("Ta ksiazka wlasnie wypozyczona przez " + borrowerName);
            return true;
        }

        public bool ReturnBook(string bookId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException("Nie znaleziono");
            }
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Książka nie była wypożyczona.");
            }

            book.IsAvailable = true;
            Console.WriteLine("Ta ksiazka wlasnie zwrocona przez ");
            return true;

        }
    }
}
