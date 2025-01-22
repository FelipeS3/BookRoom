using BookRoom.Core.Enum;

namespace BookRoom.Core.Entities;

public class Book : BaseEntity
{
    protected Book() {}

    public Book(string title, string author, string isbn, int yearPublication)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublication = yearPublication;

        Status = BookStatusEnum.Available;
        Loans = new List<Loan>();
    }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int YearPublication { get; private set; }
    public int OnHand { get; private set; }
    public int LoanQuantity { get; private set; }
    public BookStatusEnum Status { get; set; }
    public List<Loan> Loans { get; private set; }

    public void Update(string title, string author, string isbn,int yearPublication )
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublication = yearPublication;
    }

    public void Unavailable()
    {
        if(Status == BookStatusEnum.Available) Status = BookStatusEnum.Unavailable;
    }

    public void IncreaseOnHand(int increaseOnHand)
    {
        OnHand += increaseOnHand;
    }

    public void DecreaseOnHand(int decreaseOnHand)
    {
        OnHand -= decreaseOnHand;
        LoanQuantity += decreaseOnHand;
    }

    public void ReturnedOnHand(int returnedOnHand)
    {
        OnHand += returnedOnHand;
        LoanQuantity -= returnedOnHand;
    }
}
