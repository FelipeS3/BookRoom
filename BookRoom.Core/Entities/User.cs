using System.Data;

namespace BookRoom.Core.Entities;

public class User : BaseEntity
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;

        CreatedAt = DateTime.Now;
        Active = true;
        Loans = new List<Loan>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<Loan> Loans { get; private set; }

    public void Inactive()
    {
        if (Active == true) Active = false;
    }
}