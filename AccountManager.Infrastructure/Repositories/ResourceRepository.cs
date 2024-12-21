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
        private readonly string _resourceFilePath;
        private readonly string _resourceImagesPath;

        public ResourceRepository()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            _resourceFilePath = Path.Combine(appDataPath, "Resources.json");
            if (!File.Exists(_resourceFilePath))
            {
                File.Create(_resourceFilePath);
            }

            _resourceImagesPath = Path.Combine(appDataPath, "Images", "Resource");
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
            resources.Add(entity);
            var serializedResources = JsonConvert.SerializeObject(resources);
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);
            File.Copy(entity.ImagePath, _resourceImagesPath);
        }

        public async Task<bool> UpdateAsync(Resource entity)
        {
            var resources = await GetAllAsync();
            
            var resource = resources.FirstOrDefault(r => r.Id == entity.Id);
            if (resource == null)
            {
                return false;
            }

            resource.Name = entity.Name;
            resource.ImagePath = entity.ImagePath;

            var serializedResources = JsonConvert.SerializeObject(resources);
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);

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