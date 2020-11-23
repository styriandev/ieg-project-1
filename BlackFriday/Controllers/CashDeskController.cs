using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlackFriday.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Polly;

namespace BlackFriday.Controllers
{
    [Produces("application/json")]
    [Route("api/CashDesk")]
    public class CashDeskController : Controller
    {

        private readonly ILogger<CashDeskController> _logger;
        private PaymentServiceProxy<IEnumerable<string>> paymentServiceProxy;

        public CashDeskController(ILogger<CashDeskController> logger)
        {
            _logger = logger;
            paymentServiceProxy = PaymentServiceProxy<IEnumerable<string>>.GetInstance();
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            return Content("OK");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Basket basket)
        {
           _logger.LogError("TransactionInfo Creditcard: {0} Product:{1} Amount: {2}", new object[] { basket.CustomerCreditCardnumber, basket.Product, basket.AmountInEuro});

            //Mapping
            CreditcardTransaction creditCardTransaction = new CreditcardTransaction()
            {
                Amount = basket.AmountInEuro,
                CreditcardNumber = basket.CustomerCreditCardnumber,
                ReceiverName = basket.Vendor
            };

            string url = paymentServiceProxy.GetCurrentUrl();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Policy
                   .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                   .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
                   {
                       _logger.LogWarning($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                   })
                   .ExecuteAsync(() => client.PostAsJsonAsync(url + "/api/CreditcardTransactions", creditCardTransaction));

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Response was successful.");
            }
            else
            {
                _logger.LogError($"Response failed. Status code {response.StatusCode}");
            }

            return CreatedAtAction("Get", new { id = System.Guid.NewGuid() }, creditCardTransaction);
        }
    }
}