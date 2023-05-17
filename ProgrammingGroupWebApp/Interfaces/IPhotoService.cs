using CloudinaryDotNet.Actions;

namespace ProgrammingGroupWebApp.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string PublicId);
    }
}
