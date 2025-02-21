using AccountManager.Application.Common;
using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _accountManagerPath;
        private readonly string _userFilePath;

        public UserRepository()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _accountManagerPath = Path.Combine(appDataPath, "AccountManager");

            if (!Directory.Exists(_accountManagerPath))
            {
                Directory.CreateDirectory(_accountManagerPath); 
            }

            _userFilePath = Path.Combine(_accountManagerPath, "Users.json");
            if (!File.Exists(_userFilePath))
            {
                File.Create(_userFilePath);
            }
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var users = await File.ReadAllTextAsync(_userFilePath);
            if (string.IsNullOrEmpty(users?.Trim()))
            {
                users = "[]";
            }

            return JsonConvert.DeserializeObject<ICollection<User>>(users);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var all = await GetAllAsync();
            var user = all.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new NotFoundException($"Пользователь id={id} не существует");
            }

            return user;
        }

        public async Task CreateAsync(User entity)
        {
            var all = await GetAllAsync();

            var lastUser = all.LastOrDefault();
            entity.Id = lastUser == null ? 1 : lastUser.Id + 1;

            all.Add(entity);
            var deserializedAll = JsonConvert.SerializeObject(all);
            await File.WriteAllTextAsync(_userFilePath, deserializedAll, Encoding.UTF8);
        }

        public async Task UpdateAsync(User newUser)
        {
            var all = await GetAllAsync();

            var user = all.FirstOrDefault(u => u.Id == newUser.Id);
            if (user == null)
            {
                throw new NotFoundException($"Пользователь id={newUser.Id} не существует");
            }

            user.Login = newUser.Login;
            user.Password = newUser.Password;

            var deserializedAll = JsonConvert.SerializeObject(all);
            await File.WriteAllTextAsync(_userFilePath, deserializedAll, Encoding.UTF8);
        }

        public async Task DeleteAsync(User entity)
        {
            var all = await GetAllAsync();

            var user = all.FirstOrDefault(u => u.Id == entity.Id);
            if (user == null)
            {
                throw new NotFoundException($"Пользователь id={entity.Id} не существует");
            }

            all.Remove(user);
            var deserializedAll = JsonConvert.SerializeObject(all);
            await File.WriteAllTextAsync(_userFilePath, deserializedAll, Encoding.UTF8);
        }
    }
}