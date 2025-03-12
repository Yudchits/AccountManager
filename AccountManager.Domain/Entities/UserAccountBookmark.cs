namespace AccountManager.Domain.Entities
{
    public class UserAccountBookmark
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }

        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}