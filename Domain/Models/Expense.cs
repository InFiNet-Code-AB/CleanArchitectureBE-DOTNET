namespace Domain.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaidByUserId { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }

        public ICollection<ExpenseShare> Shares { get; set; } = new List<ExpenseShare>();
        public User PaidByUser { get; set; }    // To access the user who paid
        public Group Group { get; set; } // To access the group name 
    }
}
