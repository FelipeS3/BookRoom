namespace BookRoom.Application.ViewModels;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(int id,
        string name, string email, DateTime createdAt, bool active, List<LoanDetailsViewModel> loans)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = createdAt;
        Active = active;
        Loans = loans;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public List<LoanDetailsViewModel> Loans { get; private set; }
}