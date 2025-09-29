using Clinic.Api.Application.Interfaces;

namespace Clinic.Api.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<string> SaveFileAsync(string base64, string fileName, string folderPath, IWebHostEnvironment env)
        {
            var uploadPath = Path.Combine(env.ContentRootPath, folderPath);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileBytes = Convert.FromBase64String(base64);

            var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            await File.WriteAllBytesAsync(filePath, fileBytes);

            return Path.Combine(folderPath, uniqueFileName);
        }
    }
}
