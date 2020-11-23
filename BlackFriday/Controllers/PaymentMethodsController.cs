using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BlackFriday.Controllers
{
    [Produces("application/json")]
    [Route("api/PaymentMethods")]
    public class PaymentMethodsController : Controller
    {
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        private readonly ILogger<PaymentMethodsController> _logger;
        private PaymentServiceProxy<IEnumerable<string>> paymentServiceProxy;

        public PaymentMethodsController(ILogger<PaymentMethodsController> logger)
        {
            _logger = logger;
            paymentServiceProxy = PaymentServiceProxy<IEnumerable<string>>.GetInstance();
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> acceptedPaymentMethods = null;//= new string[] { "Diners", "Master" };
            _logger.LogError("Accepted Paymentmethods");

            return paymentServiceProxy.GetRequest("/api/AcceptedCreditCards");
        }
    }
}