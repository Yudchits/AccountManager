using AccountManager.Application.Repositories.Common;
using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<ICollection<Account>> GetByResourceIdAsync(int resourceId);
        Task DeleteByResourceId(int resourceId);
    }
}