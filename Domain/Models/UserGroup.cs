namespace Domain.Models
{
    public class UserGroup
    {
        public int UserId { get; set; } // FK → User
        public User User { get; set; } // Navigation property, gives access to related user

        public int GroupId { get; set; } // FK → refers to Group
        public Group Group { get; set; } // Navigation property, gives acces to the related group
    }
}
