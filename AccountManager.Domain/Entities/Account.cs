namespace AccountManager.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ResourceId { get; set; }
        public int UserId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual User User { get; set; }
    }
}