﻿using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using AccountManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.Infrastructure.Repositories
{
    public class UserAccountBookmarkRepository : IUserAccountBookmarkRepository
    {
        private readonly AccountManagerDbContext _context;

        public UserAccountBookmarkRepository(AccountManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserAccountBookmark>> GetByUserId(int userId)
        {
            return await _context.UserAccountBookmarks
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task Create(UserAccountBookmark bookmark)
        {
            _context.UserAccountBookmarks.Add(bookmark);
            await SaveChangesAsync();
        }

        public async Task Delete(UserAccountBookmark bookmark)
        {
            int bookmarkAccountId = bookmark.AccountId;
            
            var bookmarkDb = _context.UserAccountBookmarks.Where(b => b.AccountId == bookmarkAccountId);
            if (bookmarkDb == null)
            {
                throw new NotFoundException(nameof(UserAccountBookmark.AccountId), $"Не удалось найти закладку accountId={bookmarkAccountId}");
            }

            _context.Remove(bookmarkDb);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}