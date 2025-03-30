// See https://aka.ms/new-console-template for more information
public class Book
{
    public string Id {
        get { return Id; }
        private set { Id = value; }
    }
    public string Title
    {
        get { return Title; }
        private set { Title = value; }
    }
    public string Author
    {
        get { return Author; }
        private set { Author = value; }
    }

    public bool IsAvailable
    {
        get { return IsAvailable; }
        private set { IsAvailable = value; }
    }

    public Book(string id, string title, string author)
    {
        this.Id = id;
        this.Title = title;
        this.Author = author;
        this.IsAvailable = true;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Title} od {Author} - ID: {Id} jest {(IsAvailable ? "Dsotepne" : "Niedostpene")}");
    }
}