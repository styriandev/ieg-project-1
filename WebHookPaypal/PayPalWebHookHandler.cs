using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHookPaypal
{
    public class PayPalWebHookHandler : WebHookHandler
    {

        public PayPalWebHookHandler()
        {
            this.Receiver = PayPalWebHookHandler.ReceiverName;
        }
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        { // For more information about PayPal WebHook payloads, please see 
            // 'https://developer.paypal.com/docs/integration/direct/webhooks/'
            JObject entry = context.GetDataOrDefault<JObject>();

            return Task.FromResult(true);
        }
    }
}
