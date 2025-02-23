using AccountManager.Domain.Entities.Common;
using System.Collections.Generic;

namespace AccountManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}