using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IResourceRepository
    {
        Task CreateAsync(Resource entity);
        Task UpdateAsync(Resource entity);
        Task DeleteAsync(Resource entity);
        Task<Resource> GetByIdAsync(int id);
        Task<ICollection<Resource>> GetAllAsync();
        Task<ICollection<Resource>> GetAllDescByUserIdAsync(int userId);
    }
}