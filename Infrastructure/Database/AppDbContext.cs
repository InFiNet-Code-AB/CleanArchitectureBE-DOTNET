using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseShare> ExpenseShares { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for UserGroup
            modelBuilder.Entity<UserGroup>()
                .HasKey(userGroup => new { userGroup.UserId, userGroup.GroupId });

            // Composite key for ExpenseShare
            modelBuilder.Entity<ExpenseShare>()
                .HasKey(expenseShare => new { expenseShare.ExpenseId, expenseShare.UserId });

            // UserGroup relationships
            modelBuilder.Entity<UserGroup>()
                .HasOne(userGroup => userGroup.User)
                .WithMany(user => user.UserGroups)
                .HasForeignKey(userGroup => userGroup.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(userGroup => userGroup.Group)
                .WithMany(group => group.Members)
                .HasForeignKey(userGroup => userGroup.GroupId);

            // ExpenseShare relationships
            modelBuilder.Entity<ExpenseShare>()
                .HasOne(expenseShare => expenseShare.User)
                .WithMany(user => user.ExpenseShares)
                .HasForeignKey(expenseShare => expenseShare.UserId);

            modelBuilder.Entity<ExpenseShare>()
                .HasOne(expenseShare => expenseShare.Expense)
                .WithMany(expense => expense.Shares)
                .HasForeignKey(expenseShare => expenseShare.ExpenseId);

            // Group → AdminUser (one-to-many: User → Groups where user is admin)
            modelBuilder.Entity<Group>()
                .HasOne(group => group.AdminUser)
                .WithMany(user => user.GroupsAdministered)
                .HasForeignKey(group => group.AdminUserId)
                .OnDelete(DeleteBehavior.Restrict); // Admin cant be deleted, change admin first

            // Expense → PaidByUser
            modelBuilder.Entity<Expense>()
                .HasOne(expense => expense.PaidByUser)
                .WithMany(user => user.ExpensesPaid)
                .HasForeignKey(expense => expense.PaidByUserId)
                .OnDelete(DeleteBehavior.Restrict); // A user who has unpaid expenses cant be deleted

            // Expense → Group
            modelBuilder.Entity<Expense>()
                .HasOne(expense => expense.Group)
                .WithMany(group => group.Expenses)
                .HasForeignKey(expense => expense.GroupId);
        }
    }
}
