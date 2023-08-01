using Azure.Storage.Blobs;

namespace bookingdotcom.Services
{
    public class AzureService : IAzureService
    {
        private readonly IConfiguration? _config ;
        string containerName = "containerkaka";
        public BlobServiceClient _blogServiceClient{set;get;}
        public BlobContainerClient _containerClient{set;get;}
        public AzureService(IConfiguration config)
        {
            _blogServiceClient = new BlobServiceClient(config.GetSection("AzureStorage:ConnectionStrings").Value);
            _containerClient = _blogServiceClient.GetBlobContainerClient(containerName);
            _containerClient.CreateIfNotExists();
        }
       public async Task<List<string?>?> UploadLocationImages(IFormFile[] file)
       {
            // Kiểm tra xem tệp tin đã được chọn hay chưa
            if(file!=null&&file.Length>0)
            {
                var result = new List<string?>();
                foreach(var item in file)
                {
                    if(item==null) continue;
                    // Tên blob sẽ bằng tên của tệp tin gốc
                    string filename = Guid.NewGuid().ToString()+Path.GetFileName(item.FileName);
                    string blobName = Path.Combine("locations","images",filename);

                    // Lấy tham chiếu đến blob (tệp tin) trong container
                    BlobClient blobClient = _containerClient.GetBlobClient(blobName);

                    // Tải lên dữ liệu từ IFormFile vào blob
                    using (var stream = item.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, true);
                    }
                    result.Add(blobClient.Uri.ToString());
                }
                return result;
            }
            else
            {
                return null;
            }
       }
       public async Task<string?> UploadLocationPoster(IFormFile file)
       {
            if(file!=null&&file.FileName.Length>0)
            {
                string filename = Guid.NewGuid().ToString()+Path.GetFileName(file.FileName).ToString();
                string blobPath = Path.Combine("locations","poster",filename);
                BlobClient blobClient = _containerClient.GetBlobClient(blobPath);
                using(var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream,true);
                }
                return blobClient.Uri.ToString();
            }else return null;
       }
    }
}