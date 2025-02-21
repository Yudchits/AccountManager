using AccountManager.Application.Repositories.Common;
using AccountManager.Domain.Entities;

namespace AccountManager.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}