namespace bookingdotcom.Services
{
    public interface IAzureService
    {
        Task<List<string?>?> UploadLocationImages(IFormFile[] file);
        Task<string?> UploadLocationPoster(IFormFile file);
        Task<List<string?>?> UploadRoomImages(IFormFile[] file);
    }
}