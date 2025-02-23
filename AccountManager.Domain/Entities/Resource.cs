using AccountManager.Domain.Entities.Common;
using System.Collections.Generic;

namespace AccountManager.Domain.Entities
{
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}