using AccountManager.Application.Common.Exceptions;
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
    public class AccountRepository : IAccountRepository
    {
        private readonly string _accountManagerPath;
        private readonly string _accountFilePath;

        public AccountRepository()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _accountManagerPath = Path.Combine(appDataPath, "AccountManager");

            if (!Directory.Exists(_accountManagerPath))
            {
                Directory.CreateDirectory(_accountManagerPath);
            }

            _accountFilePath = Path.Combine(_accountManagerPath, "Accounts.json");
            if (!File.Exists(_accountFilePath))
            {
                File.Create(_accountFilePath);
            }
        }

        public async Task<ICollection<Account>> GetAllAsync()
        {
            var accounts = await File.ReadAllTextAsync(_accountFilePath);

            if (string.IsNullOrEmpty(accounts))
            {
                accounts = "[]";
            }

            var deserializedAccounts = JsonConvert.DeserializeObject<ICollection<Account>>(accounts);
            return deserializedAccounts;
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            var accounts = await GetAllAsync();
            return accounts.FirstOrDefault(a => a.Id == id);
        }

        public async Task<ICollection<Account>> GetByResourceIdAsync(int resourceId, int userId)
        {
            var accounts = await GetAllAsync();
            return accounts.Where(a => a.ResourceId == resourceId && a.UserId == userId).ToList();
        }

        public async Task CreateAsync(Account entity)
        {
            var accounts = await GetAllAsync();
            
            var last = accounts.LastOrDefault();
            entity.Id = last != null ? last.Id + 1 : 1;
            
            accounts.Add(entity);
            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);
        }

        public async Task UpdateAsync(Account entity)
        {
            var accounts = await GetAllAsync();

            int accountId = entity.Id;
            var account = accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                throw new NotFoundException(nameof(Account.Id), $"Аккаунт id={accountId} не существует");
            }

            account.ResourceId = entity.ResourceId;
            account.Name = entity.Name;
            account.Login = entity.Login;
            account.Password = entity.Password;

            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);
        }

        public async Task DeleteAsync(Account entity)
        {
            var accounts = await GetAllAsync();

            int accountId = entity.Id;
            var account = accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                throw new NotFoundException(nameof(Resource.Id), $"Аккаунт id={accountId} не существует");
            }

            var isDeleted = accounts.Remove(account);
            if (!isDeleted)
            {
                throw new InternalServerException($"Не удалось удалить аккаунт id={accountId}");
            }

            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);
        }

        public async Task DeleteByResourceId(int resourceId)
        {
            var accounts = await GetAllAsync();
            accounts = accounts.Where(a => a.ResourceId != resourceId).ToList();
            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);
        }
    }
}