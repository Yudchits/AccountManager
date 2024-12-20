using AccountManager.Domain.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<int> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> GetById(int id);
        Task<ICollection<T>> GetAll();
    }
}