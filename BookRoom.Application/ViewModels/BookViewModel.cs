namespace BookRoom.Application.ViewModels;

public class BookViewModel
{
    public BookViewModel(int id, string title, string author, int yearPublication)
    {
        Id = id;
        Title = title;
        Author = author;
        YearPublication = yearPublication;
    }
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int YearPublication { get; private set; }
}