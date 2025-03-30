// See https://aka.ms/new-console-template for more information
public class Book
{
    private string id;
    private string title;
    private string author;
    private bool isAvailable;
    public string Id {
        get { return id; }
        private set { id = value; }
    }
    public string Title
    {
        get { return title; }
        private set { title = value; }
    }
    public string Author
    {
        get { return author; }
        private set { author = value; }
    }

    public bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }

    public Book( string title, string author, string id)
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