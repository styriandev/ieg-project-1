using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Model;

namespace PaymentService.Controllers
{
    [Route("api/paymentcontroller")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private List<Payment> Payments;

        public PaymentController()
        {
            this.Payments = new List<Payment>();
            this.Payments.Add(new Payment { Amount = 0, PayedWith = "Visa" });
            this.Payments.Add(new Payment { Amount = 4, PayedWith = "Master-Card" });
        }

        [HttpGet]
        public List<Payment> GetPayments()
        {
            return this.Payments;
        }

        [HttpPost]
        public List<Payment> AddPayment(Payment payment)
        {
            this.Payments.Add(payment);
            return this.Payments;
        }
    }
}