using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Model
{
    public class Payment
    {
        public string PayedWith { get; set; }
        public float Amount { get; set; }
    }
}
