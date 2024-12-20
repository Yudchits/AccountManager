using AccountManager.Domain.Entities.Common;

namespace AccountManager.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int ResourceId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}