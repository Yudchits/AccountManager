using AccountManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Application.Repositories
{
    public interface IUserAccountBookmarkRepository
    {
        Task<ICollection<UserAccountBookmark>> GetByUserId(int userId);
        Task Create(UserAccountBookmark bookmark);
        Task Delete(UserAccountBookmark bookmark);
    }
}