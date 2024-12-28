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

        public async Task<ICollection<Account>> GetByResourceId(int resourceId)
        {
            var accounts = await GetAllAsync();
            return accounts.Where(a => a.ResourceId == resourceId).ToList();
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

        public async Task<bool> UpdateAsync(Account entity)
        {
            var accounts = await GetAllAsync();

            var account = accounts.FirstOrDefault(a => a.Id == entity.Id);
            if (account == null)
            {
                return false;
            }

            account.ResourceId = entity.ResourceId;
            account.Login = entity.Login;
            account.Password = entity.Password;

            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);

            return true;
        }

        public async Task<bool> DeleteAsync(Account entity)
        {
            var accounts = await GetAllAsync();
            
            var account = accounts.FirstOrDefault(a => a.Id == entity.Id);
            if (account == null)
            {
                return false;
            }

            var isDeleted = accounts.Remove(account);
            if (!isDeleted)
            {
                return false;
            }

            var serializedAccounts = JsonConvert.SerializeObject(accounts);
            await File.WriteAllTextAsync(_accountFilePath, serializedAccounts, Encoding.UTF8);
            return true;
        }
    }
}