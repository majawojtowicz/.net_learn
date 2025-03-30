using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public interface IBookOperations
    {
        bool BorrowBook(int bookId, string borrowerName);
        bool ReturnBook(int bookId);
    }
}
