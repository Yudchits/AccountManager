using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using AccountManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountManagerDbContext _context;

        public UserRepository(AccountManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User.Id), $"Пользователь id={id} не существует");
            }

            return user;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
            {
                throw new NotFoundException(nameof(User.Login), $"Пользователь не существует");
            }

            return user;
        }

        public async Task<int> CreateAsync(User entity)
        {
            var login = entity.Login;
            var userByLogin = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (userByLogin != null)
            {
                throw new ConflictException(nameof(User.Login), "Пользователь уже существует");
            }

            _context.Users.Add(entity);
            await SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(User newUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == newUser.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User.Id), $"Пользователь id={newUser.Id} не существует");
            }

            user.Login = newUser.Login;
            user.Password = newUser.Password;
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User.Id), $"Пользователь id={entity.Id} не существует");
            }

            _context.Users.Remove(user);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}