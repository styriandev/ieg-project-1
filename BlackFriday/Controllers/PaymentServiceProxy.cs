using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlackFriday.Controllers
{
    public class PaymentServiceProxy<T>
    {
        private static List<string> availableServices = new List<string>();
        private int current;
        private static PaymentServiceProxy<T> instance;

        private PaymentServiceProxy()
        {
            availableServices.Add("https://iegeasycreditcardservicesecond.azurewebsites.net/");
            this.current = 0;
            availableServices.Add("https://iegeasycreditcardservice20201010133848.azurewebsites.net/");
        }

        public static PaymentServiceProxy<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new PaymentServiceProxy<T>();
            }
            return instance;
        }

        public string GetCurrentUrl()
        {
            var currentUrl = availableServices.ElementAt(current);
            if (current == availableServices.Count)
            {
                current = 0;
            }
            else
            {
                current++;
            }
            return currentUrl;
        }

        public T GetRequest(string url)
        {
            HttpClient client = new HttpClient();
            var currentUrl = GetCurrentUrl();

            client.BaseAddress = new Uri(currentUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(currentUrl + "/api/AcceptedCreditCards").Result;
            if (response.IsSuccessStatusCode)
            {
               return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception("Nothing was found!");    
            }
        }
    }
}
