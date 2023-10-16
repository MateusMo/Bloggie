using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Bloggie.Web.Repositories
{
    public class ImageRepositoryCloudinary : IImageRepository
    {
        private readonly Account _Account;
        public ImageRepositoryCloudinary(IConfiguration IConfiguration)
        {
            _Account = new Account(
                IConfiguration.GetSection("Cloudinary")["CloudName"],
                IConfiguration.GetSection("Cloudinary")["ApiKey"],
                IConfiguration.GetSection("Cloudinary")["ApiSecret"]
                );
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(_Account);
            var uploadFileResult = await client.UploadAsync(
                    new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, file.OpenReadStream()),
                        DisplayName = file.FileName
                    }
                );

            if(uploadFileResult != null && uploadFileResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadFileResult.SecureUri.ToString();
            }

            return null;
        }
    }
}
