using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.Create
{
    public class CreateResourceHandler : IRequestHandler<CreateResourceRequest, CreateResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public CreateResourceHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateResourceResponse> Handle(CreateResourceRequest request, CancellationToken cancellationToken)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string resourceImagesPath = Path.Combine(appDataPath, "AccountManager", "Images", "Resources");
            
            if (!Directory.Exists(resourceImagesPath))
            {
                Directory.CreateDirectory(resourceImagesPath);
            }

            string requestImagePath = request.ImagePath;
            string dbImagePath = ConvertImagePathToDbImagePath(resourceImagesPath, request.ImagePath); 
            File.Copy(requestImagePath, dbImagePath, true);

            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            resourceDb.ImagePath = dbImagePath;
            
            await _repository.CreateAsync(resourceDb);
            return _mapper.Map<CreateResourceResponse>(resourceDb);
        }

        private static string ConvertImagePathToDbImagePath(string resourceImagesPath, string imagePath)
        {
            int formatDot = imagePath.LastIndexOf('.');
            if (formatDot != -1)
            {
                string fileFormat = imagePath.Substring(formatDot, imagePath.Length - formatDot);
                var guid = Guid.NewGuid();

                return Path.Combine(resourceImagesPath, string.Concat(guid, fileFormat));
            }

            throw new ArgumentException($"Не удалось конвертировать путь (appdata: {resourceImagesPath}, imagepath: {imagePath} )");
        }
    }
}