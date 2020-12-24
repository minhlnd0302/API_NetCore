using Azure.Storage;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionModels.FilesMGT
{
    public static class AzureStorageConfig
    {
        public static string AccountName { get; set; } = "minhlnd";
        public static string ImageContainer { get; set; } = "tgdd";
        public static string AccountKey { get; set; } = "JLVG7Mx8CHfV3bt4SzwnVL0y0+RrIR9nZX+Rd4UbJFGpgdAjBAF2En4aDwrqU/y7aVWY2/0MnBrpTKELYVD2Xw==";
    }
    public class FilesUpload
    {
        
        public static async Task<bool> UploadFileToStorage(Stream fileStream, string fileName)
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

            return await Task.FromResult(true);
        }
    }
}
