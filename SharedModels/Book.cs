namespace SharedModels;

public class Book
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required int Year  { get; init; }

    public override string ToString()
    {
        return $"{Id} - {Title} - {Author} - {Year}";
    }
}
