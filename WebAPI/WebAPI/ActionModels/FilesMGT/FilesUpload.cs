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
        //public static string AccountKey { get; set; } = "JLVG7Mx8CHfV3bt4SzwnVL0y0+RrIR9nZX+Rd4UbJFGpgdAjBAF2En4aDwrqU/y7aVWY2/0MnBrpTKELYVD2Xw==";
        public static string AccountKey { get; set; } = "UzQ9O0+w9/MYCdDWvtWZ3gJDZx54VqkU0n/tuvvzEqGnSOzFTmZldM3EX/Lt29sI/jF5CqPDO0Ki8brHmKTKow==";
    }
    public class FilesUpload : ControllerBase
    {
        private Stream fileStream { get; set; }
        private string fileName { get; set; }
        private long productId { get; set; }
        public FilesUpload(IFormFile file, long productId)
        {
            this.fileStream = file.OpenReadStream();
            this.fileName = file.FileName;
            this.productId = productId;
        } 
        public async Task<ActionResult<bool>> Excute()
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


            // add image to db
            {
                var _context = new TGDDContext();

                var newImageId = _context.Images.Max(Image => Image.Id) + 1;


                var image = new Image()
                {
                    Id = newImageId,
                    Url = blobUri.ToString(),
                    ProductId = this.productId
                }; 

                _context.Images.Add(image);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    bool imageExist = _context.Images.Any(img => img.Id == image.Id);
                    if (imageExist)
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            } 
            return await Task.FromResult(true);
        }
    }
}
