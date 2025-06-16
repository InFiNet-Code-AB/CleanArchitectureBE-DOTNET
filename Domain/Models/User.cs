namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }

        // Navigation properties 
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>(); // Shows which groups the user is part of
        public ICollection<Group> GroupsAdministered { get; set; } = new List<Group>(); // Shows all groups where user is admin
        public ICollection<Expense> ExpensesPaid { get; set; } = new List<Expense>(); // Shows which expenses this user has paid
        public ICollection<ExpenseShare> ExpenseShares { get; set; } = new List<ExpenseShare>(); // Shows all expese shares where this user owes money
    }
}
