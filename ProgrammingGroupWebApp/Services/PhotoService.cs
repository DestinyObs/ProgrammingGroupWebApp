using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgrammingGroupWebApp.Helpers;
using ProgrammingGroupWebApp.Interfaces;
using System.Net.WebSockets;

namespace ProgrammingGroupWebApp.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;


        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
            {
                Cloud = "diajdiurh",
                ApiKey = "245272367391712",
                ApiSecret = "_yGJIVp_KnqjekgXytEqpdlSE_A"
            };

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if ( file.Length > 0 )
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(250).Width(300).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string PublicId)
        {
            var deleteParams = new DeletionParams(PublicId);
            var Result = await _cloudinary.DestroyAsync(deleteParams);

            return Result;
        }

    }
}
