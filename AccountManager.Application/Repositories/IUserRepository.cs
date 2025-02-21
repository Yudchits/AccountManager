using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(User entity);
        Task<User> GetByIdAsync(int id);
        Task<ICollection<User>> GetAllAsync();
    }
}