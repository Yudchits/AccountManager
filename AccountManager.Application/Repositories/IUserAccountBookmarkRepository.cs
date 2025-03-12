using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IUserAccountBookmarkRepository
    {
        Task<ICollection<UserAccountBookmark>> GetByUserIdAsync(int userId);
        Task<int> GetCountByUserIdAsync(int userId);
        Task CreateAsync(UserAccountBookmark bookmark);
        Task DeleteAsync(UserAccountBookmark bookmark);
    }
}