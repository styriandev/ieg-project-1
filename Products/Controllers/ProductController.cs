using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;

namespace Products.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static string name = "productmemory";
        static string key = "r+ht7mNVmpA0g7aPg4amKK7B/SOwCRl6szwQmEBgwtlpgBQRXwOGuXQNFlKfILLfqWnT0ZIicHcOWikfq49O+g==";

        [HttpGet]
        public List<string> GetProducts()
        {
            var account = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(name, key), true);
            var share = account.CreateCloudFileClient().GetShareReference("productmemory");
            share.CreateIfNotExistsAsync();

            var fileRef = share.GetRootDirectoryReference().GetFileReference("products.json");
            var test = fileRef.DownloadTextAsync().Result;
            var result = JsonConvert.DeserializeObject<ProductFileContent>(test);
            //fileRef.UploadFromFileAsync(@"C:\dosa\Fortbildung\campus02\master\semester1\ieg\SolHandelsplattform\products.json");
            return result.products;
            // return response.Content.;
        }
    }
}