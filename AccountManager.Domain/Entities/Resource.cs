using AccountManager.Domain.Entities.Common;

namespace AccountManager.Domain.Entities
{
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
    }
}