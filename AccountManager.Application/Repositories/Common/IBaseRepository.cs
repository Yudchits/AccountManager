using AccountManager.Domain.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
    }
}