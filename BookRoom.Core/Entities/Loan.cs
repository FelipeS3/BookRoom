namespace BookRoom.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(int idUser, int idBook)
    {
        IdUser = idUser;
        IdBook = idBook;

        LoanedQuantity = 1;
        LoanDate = DateTime.Now;
        ReturnedDate = null;
    }

    public int IdUser { get; private set; }
    public User User { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }
    public int LoanedQuantity { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime? ReturnedDate { get; private set; }

    public void ExpectedReturnedDate(int numberLoanDay)
    {
        ExpectedReturnDate = LoanDate.AddDays(numberLoanDay);
    }

    public void RenewLoan(int renew)
    {
        ExpectedReturnDate = ExpectedReturnDate.AddDays(renew);
    }

    public void ReturnedBook()
    {
        ReturnedDate = DateTime.Now;
    }
}