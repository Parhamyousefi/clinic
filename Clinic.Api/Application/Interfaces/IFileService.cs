namespace Clinic.Api.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(string base64, string fileName, string folderPath, IWebHostEnvironment env);
    }
}
