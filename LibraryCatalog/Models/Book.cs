public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} - {(IsAvailable ? "Available" : "Borrowed")}";
    }
}
