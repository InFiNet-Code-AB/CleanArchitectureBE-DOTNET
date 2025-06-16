namespace Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdminUserId { get; set; } // The User who created the group

        // Navigation properties
        public ICollection<UserGroup> Members { get; set; } = new List<UserGroup>(); // Shows all members of this group
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>(); // All Expenses associated with this group

        public User AdminUser { get; set; } // The User who created the group
    }
}
