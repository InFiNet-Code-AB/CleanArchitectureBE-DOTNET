namespace Domain.Models
{
    public class ExpenseShare
    {
        // Composite Key (set in DbContext)
        public int ExpenseId { get; set; }
        public int UserId { get; set; }

        public decimal ShareAmount { get; set; }
        public bool IsSettled { get; set; }

        // Navigation properties
        public Expense Expense { get; set; }  // FK → Expense
        public User User { get; set; }        // FK → User
    }
}
