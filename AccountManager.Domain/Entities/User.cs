using System.Collections.Generic;

namespace AccountManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<UserAccountBookmark> AccountBookmarks { get; set; }
    }
}