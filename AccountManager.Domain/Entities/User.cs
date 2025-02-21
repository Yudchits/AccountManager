using AccountManager.Domain.Entities.Common;

namespace AccountManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}