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
    public class ResourceRepository : IResourceRepository
    {
        private readonly string _accountManagerPath;
        private readonly string _resourceFilePath;
        private readonly string _resourceImagesPath;

        public ResourceRepository()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _accountManagerPath = Path.Combine(appDataPath, "AccountManager");

            _resourceFilePath = Path.Combine(_accountManagerPath, "Resources.json");
            if (!File.Exists(_resourceFilePath))
            {
                File.Create(_resourceFilePath);
            }

            _resourceImagesPath = Path.Combine(_accountManagerPath, "Images", "Resources");
            if (!Directory.Exists(_resourceImagesPath))
            {
                Directory.CreateDirectory(_resourceImagesPath);
            }
        }

        public async Task<ICollection<Resource>> GetAllAsync()
        {
            var resources = await File.ReadAllTextAsync(_resourceFilePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(resources))
            {
                resources = "[]";
            }

            var deserializedResources = JsonConvert.DeserializeObject<ICollection<Resource>>(resources);
            return deserializedResources;
        }

        public async Task<Resource> GetByIdAsync(int id)
        {
            var resources = await GetAllAsync();
            return resources.FirstOrDefault(r => r.Id == id);
        }

        public async Task CreateAsync(Resource entity)
        {
            var resources = await GetAllAsync();
            
            int id = 0;
            var lastResource = resources.LastOrDefault();
            if (lastResource != null)
            {
                id = lastResource.Id + 1;
            }

            entity.Id = id;

            resources.Add(entity);
            var serializedResources = JsonConvert.SerializeObject(resources);
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);

            var imagePath = entity.ImagePath;
            File.Copy(imagePath, Path.Combine(_resourceImagesPath, entity.Name));
        }

        public async Task<bool> UpdateAsync(Resource entity)
        {
            var resources = await GetAllAsync();
            
            var resource = resources.FirstOrDefault(r => r.Id == entity.Id);
            if (resource == null)
            {
                return false;
            }

            var name = entity.Name;
            resource.Name = name;

            var imagePath = entity.ImagePath;
            resource.ImagePath = imagePath;

            var serializedResources = JsonConvert.SerializeObject(resources);
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);
            File.Copy(imagePath, Path.Combine(_resourceImagesPath, name), true);

            return true;
        }

        public async Task<bool> DeleteAsync(Resource entity)
        {
            var resources = await GetAllAsync();

            var resource = resources.FirstOrDefault(r => r.Id == entity.Id);
            if (resource == null)
            {
                return false;
            }

            var isDeleted = resources.Remove(resource);
            if (!isDeleted)
            {
                return false;
            }

            var imagePath = entity.ImagePath;
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            var serializedResources = JsonConvert.SerializeObject(resources);
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);

            return true;
        }
    }
}