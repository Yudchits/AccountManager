using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAsync(Account entity);
        Task UpdateAsync(Account entity);
        Task DeleteAsync(Account entity);
        Task<Account> GetByIdAsync(int id);
        Task<ICollection<Account>> GetAllAsync();
        Task<ICollection<Account>> GetByResourceIdAsync(int resourceId, int userId);
        Task DeleteByResourceId(int resourceId);
    }
}