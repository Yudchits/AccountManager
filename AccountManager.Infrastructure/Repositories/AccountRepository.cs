using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using AccountManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountManagerDbContext _context;

        public AccountRepository(AccountManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (acc == null)
            {
                throw new NotFoundException(nameof(Account.Id), $"Аккаунт id={id} не существует");
            }

            return acc;
        }

        public async Task<ICollection<Account>> GetByResourceIdAsync(int resourceId, int userId)
        {
            return await _context.Accounts
                .Where(a => a.ResourceId == resourceId && a.UserId == userId)
                .ToListAsync();
        }

        public async Task CreateAsync(Account entity)
        {
            _context.Accounts.Add(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            int accountId = entity.Id;
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null)
            {
                throw new NotFoundException(nameof(Account.Id), $"Аккаунт id={accountId} не существует");
            }

            account.ResourceId = entity.ResourceId;
            account.Name = entity.Name;
            account.Login = entity.Login;
            account.Password = entity.Password;

            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Account entity)
        {
            int accountId = entity.Id;
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null)
            {
                throw new NotFoundException(nameof(Resource.Id), $"Аккаунт id={accountId} не существует");
            }

            _context.Accounts.Remove(account);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}