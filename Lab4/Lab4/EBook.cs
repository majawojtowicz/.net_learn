using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class EBook : Book
    {
        public string FileFormat
        {
            get { return FileFormat; }
            private set { FileFormat = value; }
        }


        public EBook(string id,string title, string author, string fileFormat):base(id, title, author)
        {
            this.FileFormat = fileFormat;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Format: {FileFormat}");
        }
    }
}
