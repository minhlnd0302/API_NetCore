using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.FilesMGT
{
    public static class AzureStorageConfig
    {
        public static string AccountName { get; set; } = "minhlnd";
        public static string ImageContainer { get; set; } = "tgdd";
        public static string AccountKey { get; set; } = "WBMxk8lv52qhcbjDhm2Sl4jIQYiYL8W8LS1FG7YCiw3o9K4B6MRmgEYLM6H2jDSmzUCdhUBF+jnm3Omy1Lcc9A==";
        //public static string AccountKey { get; set; } = "UzQ9O0+w9/MYCdDWvtWZ3gJDZx54VqkU0n/tuvvzEqGnSOzFTmZldM3EX/Lt29sI/jF5CqPDO0Ki8brHmKTKow==";
    }
    public class FilesUpload : ControllerBase
    {
        private Stream fileStream { get; set; }
        private string fileName { get; set; } 
        public FilesUpload(IFormFile file)
        {
            this.fileStream = file.OpenReadStream();
            this.fileName = file.FileName; 
        } 
        public async Task<Uri> Excute()
        {
            // Create a URI to the blob
            Uri blobUri = new Uri("https://" + AzureStorageConfig.AccountName +
                                  ".blob.core.windows.net/" +
                                  AzureStorageConfig.ImageContainer +
                                  "/" + fileName);

            // Create StorageSharedKeyCredentials object by reading
            // the values from the configuration (appsettings.json)
            StorageSharedKeyCredential storageCredentials =
                new StorageSharedKeyCredential(AzureStorageConfig.AccountName, AzureStorageConfig.AccountKey);

            // Create the blob client.
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            // Upload the file
            await blobClient.UploadAsync(fileStream);

            await Task.FromResult(true);


            return blobUri;
        }
    }
}
