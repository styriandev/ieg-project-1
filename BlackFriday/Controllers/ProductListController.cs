using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackFriday.Controllers
{
    [Route("api/[controller]")]
    public class ProductListController : Controller
    {
        private static string urlLocalDataStore = "https://productslocaldatastore.azurewebsites.net";
        private static string urlFromFile = "https://productsfromfile.azurewebsites.net";

        // GET: http://iegblackfriday.azurewebsites.net/api/productlist
        [HttpGet]
        public IEnumerable<string> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlLocalDataStore);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> productsAvailable = new List<string>();

            List<string> servicesToAccess = new List<string>();
            servicesToAccess.Add(urlLocalDataStore);
            servicesToAccess.Add(urlFromFile);

            servicesToAccess.ForEach(service =>
            {
                HttpResponseMessage response = client.GetAsync(service + "/api/products").Result;
                if (response.IsSuccessStatusCode)
                {
                    productsAvailable.AddRange(response.Content.ReadAsAsync<List<string>>().Result);
                }
            });

            // also read products from other service

            return productsAvailable;
        }
        
    }
}
