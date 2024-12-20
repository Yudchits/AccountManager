using AccountManager.Domain.Common;

namespace AccountManager.Domain.Entities
{
    public class Resource : BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}