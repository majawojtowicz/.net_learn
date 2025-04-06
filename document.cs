// See https://aka.ms/new-console-template for more information

public interface IDocumentPrototype
{
    IDocumentPrototype Clone();
}

public class DocumentTemplate
{
    public string Header { get; set; }
    public string Footer { get; set; }

    public DocumentTemplate(string header, string footer)
    {
        Header = header;
        Footer = footer;
    }

    public DocumentTemplate Copy()
    {
        return new DocumentTemplate(Header, Footer);
    }
}

public class Document : IDocumentPrototype
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DocumentTemplate Template { get; set; }

    public Document(string title, string content, DocumentTemplate template)
    {
        Title = title;
        Content = content;
        Template = template;
    }

    public IDocumentPrototype Clone()
    {
        // głęboka kopia
        return new Document(
            title: this.Title,
            content: this.Content,
            template: this.Template.Copy()
        );
    }

    public void Display()
    {
        Console.WriteLine($"--{Template.Header} --");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine(Content);
        Console.WriteLine($"--{Template.Footer} --");
    }
}
