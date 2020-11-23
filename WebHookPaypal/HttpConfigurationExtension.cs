using Microsoft.AspNet.WebHooks.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebHookPaypal
{
    /// <summary>
    /// Extension methods for <see cref="HttpConfiguration"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class HttpConfigurationExtension
    {
        /// <summary>
        /// Initializes support for receiving Paypal WebHooks using the Paypal .NET SDK, see <c>https://www.nuget.org/packages/PayPal</c>.
        /// Configure the Paypal WebHook settings using the web.config file as described in <c>https://github.com/paypal/PayPal-NET-SDK/wiki/Webhook-Event-Validation</c>. 
        /// The corresponding WebHook URI is of the form '<c>https://&lt;host&gt;/api/webhooks/incoming/paypal</c>'.
        /// For details about Paypal WebHooks, see <c>https://developer.paypal.com/webapps/developer/docs/integration/direct/rest-webhooks-overview/</c>.
        /// </summary>
        /// <param name="config">The current <see cref="HttpConfiguration"/>config.</param>
        public static void InitializeReceivePaypalWebHooks(this HttpConfiguration config)
        {
            WebHooksConfig.Initialize(config);
        }
    }
}
