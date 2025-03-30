using System.Runtime.InteropServices;

namespace Biblioteka.Tests
{
    public class Tests
    {
        private Library library;
        [SetUp]
        public void Setup()
        {
            library = new Library();
            library.AddBook(new Book("C# Programming", "John Doe", "12345"));
        }

        [Test]
        public void BorrowBook_BookIsAvailable_True()
        {
            var wynik = library.BorrowBook("12345", "Alice");
            Assert.IsTrue(wynik);
        }

        [Test]
        public void BorrowBook_BookIsBorrowed_False()
        {
            library.BorrowBook("12345", "Alice");
            var e = Assert.Throws<InvalidOperationException>(() =>
            {
                library.BorrowBook("12345", " Charlie");
            });
                
            Assert.AreEqual("wypożyczona.", e.Message);
        }

        [Test]

        public void BorrowBook_BookNotExist_False()
        {
            var e =Assert.Throws<ArgumentException>(() =>
                {
                library.BorrowBook("maja", "Maja");
                });
                
                Assert.AreEqual("Nie znalezion książki o tym ID.", e.Message);
        }

        [Test]
        public void ReturnBook_BookBorrowed_True()
        {
            library.BorrowBook("12345", "Alice");
            var wynik = library.ReturnBook("12345");
            Assert.IsTrue(wynik);
        }

        [Test]
        public void ReturnBook_BookNotBorrowed_ThrowsInvalidOperationException()
        {
            var e = Assert.Throws<InvalidOperationException>(() =>
            {
                library.ReturnBook("12345");

            });
            Assert.AreEqual("Książka nie była wypożyczona.", e.Message);
        }

        [Test]

        public void ReturnBook_BookNotExist_ArgumentException()
        {
            var e = Assert.Throws<ArgumentException>(() =>
            {
                library.ReturnBook("278083");
            });
            Assert.AreEqual("Nie znaleziono", e.Message);
        }
    }
}