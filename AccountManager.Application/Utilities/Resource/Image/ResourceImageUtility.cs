using AccountManager.Application.Context;
using System;
using System.IO;

namespace AccountManager.Application.Utilities.Resource.Image
{
    public class ResourceImageUtility : IResourceImageUtility
    {
        private readonly DirectoryContext _directoryContext;

        public ResourceImageUtility(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        public string MoveToDbPath(string imagePath)
        {
            string imagesPath = Path.Combine(_directoryContext.AppDataPath, "Images", "Resources");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            int formatDot = imagePath.LastIndexOf('.');
            if (formatDot != -1)
            {
                string fileFormat = imagePath.Substring(formatDot, imagePath.Length - formatDot);
                var guid = Guid.NewGuid();

                string dbPath = Path.Combine(imagesPath, string.Concat(guid, fileFormat));
                File.Copy(imagePath, dbPath, true);

                return dbPath;
            }

            throw new ArgumentException($"Не удалось конвертировать путь {imagePath}");
        }
    }
}