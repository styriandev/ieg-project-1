using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http;


namespace Products.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            var account = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("?sv=2019-12-12&ss=bfqt&srt=sco&sp=rwdlacupx&se=2020-10-20T04:44:03Z&st=2020-10-19T20:44:03Z&spr=https&sig=xl2hoS%2BiaDHa8yziPw7LBmXZPVBlPAaiXNW7tQY09m8%3D"), true);
            var share = account.CreateCloudFileClient().GetShareReference("productmemory");
            share.CreateIfNotExistsAsync();
            return "";
            // return response.Content.;
        }
    }
}