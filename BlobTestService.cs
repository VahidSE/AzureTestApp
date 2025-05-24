using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;

namespace AzureTestApp
{
    public class BlobTestService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobTestService(IConfiguration configuration)
        {
            var conString = configuration["ABS:ConString"];
            var conName = configuration["ABS:ConName"];
            _containerClient = new BlobContainerClient(conString, conName);
           // UploadImagesAsync("D:\\Downloads\\abcd.jpg");
        }

        public async Task<List<string>> GetImageUrlsAsync()
        {
            var imageUrls = new List<string>();

            await foreach (var blobItem in _containerClient.GetBlobsAsync())
            {
                var blobClient = _containerClient.GetBlobClient(blobItem.Name);
                //var sasUri = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));
                //imageUrls.Add(sasUri.ToString());
                imageUrls.Add(blobClient.Uri.ToString());
            }

            return imageUrls;
        }
        public async Task UploadImagesAsync(string fileName)
        {
            try
            {
                var blobClient = _containerClient.GetBlobClient("abcd.jpg");
                FileStream fileStream = File.OpenRead(fileName);
                await blobClient.UploadAsync(fileStream, overwrite: true);
            }
            catch (Exception ex) {
                string s = "";
            }
        }
        //This is in use and working
        public async Task UploadImagesAsync(string fileName, Stream fileStream)
        {
            try
            {
                var blobClient = _containerClient.GetBlobClient(fileName);
                //FileStream fileStream = File.OpenRead(fileName);
                await blobClient.UploadAsync(fileStream, overwrite: true);
            }
            catch (Exception ex)
            {
                string s = "";
            }
        }

    //This is when you have to pass large files as chunks
    public async Task UploadFileAsync(string fileName, IBrowserFile file)
    {
        await _containerClient.CreateIfNotExistsAsync();

        var blobClient = _containerClient.GetBlockBlobClient(fileName);
        var blockSize = 4 * 1024 * 1024; // 4 MB blocks
        var blockIds = new List<string>();
        var fileStream = file.OpenReadStream(long.MaxValue); // Set max allowed size
        var buffer = new byte[blockSize];
        int bytesRead, blockNumber = 0;

            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                var blockId = Convert.ToBase64String(BitConverter.GetBytes(blockNumber++));
                blockIds.Add(blockId);

                using var blockStream = new MemoryStream(buffer, 0, bytesRead);
                await blobClient.StageBlockAsync(blockId, blockStream);
            }

            await blobClient.CommitBlockListAsync(blockIds);
    }
}
}
