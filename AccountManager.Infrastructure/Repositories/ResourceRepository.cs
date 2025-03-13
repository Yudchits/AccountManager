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
    public class ResourceRepository : IResourceRepository
    {
        private readonly AccountManagerDbContext _context;

        public ResourceRepository(AccountManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Resource>> GetAllAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<ICollection<Resource>> GetAllDescByUserIdAsync(int userId)
        {
            return await _context.Resources
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.Id)
                .ToListAsync();
        }

        public async Task<Resource> GetByIdAsync(int id)
        {
            var resource = await _context.Resources.FirstOrDefaultAsync(r => r.Id == id);
            if (resource == null)
            {
                throw new NotFoundException(nameof(Resource.Id), $"Ресурс id={id} не существует");
            }

            return resource;
        }

        public async Task<bool> CheckCountAsync(int userId)
        {
            return await _context.Resources
                .Where(r => r.UserId == userId)
                .AnyAsync();
        }

        public async Task CreateAsync(Resource entity)
        {
            _context.Resources.Add(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Resource newResource)
        {
            var resources = await GetAllAsync();

            int newResourceId = newResource.Id;
            var currentResource = resources.FirstOrDefault(r => r.Id == newResourceId);
            if (currentResource == null)
            {
                throw new NotFoundException(nameof(Resource.Id), $"Ресурс id={newResourceId} не существует");
            }

            currentResource.Name = newResource.Name;
            currentResource.ImagePath = newResource.ImagePath;

            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Resource entity)
        {
            var resource = await _context.Resources.FirstOrDefaultAsync(r => r.Id == entity.Id);
            if (resource == null)
            {
                throw new NotFoundException(nameof(Resource.Id), $"Ресурс id={entity.Id} не существует");
            }

            _context.Resources.Remove(resource);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}