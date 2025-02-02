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
            
            var lastResource = resources.LastOrDefault();
            int id = lastResource != null ? lastResource.Id + 1 : 1;
            entity.Id = id;

            var imagePath = ConvertToDbImagePath(id, entity.ImagePath);
            File.Copy(entity.ImagePath, imagePath, true);

            entity.ImagePath = imagePath;

            resources.Add(entity);
            var serializedResources = JsonConvert.SerializeObject(resources);
            
            await File.WriteAllTextAsync(_resourceFilePath, serializedResources, Encoding.UTF8);
        }

        private string ConvertToDbImagePath(int id, string filePath)
        {
            var fileFormatStart = filePath.LastIndexOf('.');
            if (fileFormatStart == -1)
            {
                throw new BadRequestException($"Невозможно конвертировать путь '{filePath}'");
            }

            var fileFormat = filePath.Substring(fileFormatStart);
            var fileName = $"{id}{fileFormat}";

            return Path.Combine(_resourceImagesPath, fileName);
        }

        public async Task<bool> UpdateAsync(Resource newResource)
        {
            var resources = await GetAllAsync();
            
            var currentResource = resources.FirstOrDefault(r => r.Id == newResource.Id);
            if (currentResource == null)
            {
                return false;
            }

            currentResource.Name = currentResource.Name;

            var newImagePath = newResource.ImagePath;
            if (currentResource.ImagePath != newImagePath)
            {
                newImagePath = ConvertToDbImagePath(newResource.Id, newImagePath);
                File.Copy(newResource.ImagePath, newImagePath, true);

                currentResource.ImagePath = newImagePath;
            }

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