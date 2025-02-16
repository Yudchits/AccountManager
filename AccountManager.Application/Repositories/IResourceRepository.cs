using AccountManager.Application.Repositories.Common;
using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IResourceRepository : IBaseRepository<Resource>
    {
        Task<ICollection<Resource>> GetAllDescAsync();
    }
}