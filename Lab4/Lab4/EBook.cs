using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class EBook : Book
    {
        private string fileFormat;
        public string FileFormat
        {
            get { return fileFormat; }
            private set { fileFormat = value; }
        }


        public EBook(string title, string author, string id, string fileFormat):base(title, author, id)
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
