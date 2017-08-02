using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace paymentApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

   [HttpPost]
    public IActionResult Charge(string stripeToken, string stripeEmail)
    {
        var myCharge = new StripeChargeCreateOptions();

        // always set these properties
        myCharge.Amount = 100;
        myCharge.Currency = "usd";

        myCharge.ReceiptEmail = stripeEmail;
        myCharge.Description = "Test Charge";
        myCharge.SourceTokenOrExistingSourceId = stripeToken;
        myCharge.Capture = true;

        var chargeService = new StripeChargeService("sk_test_HXHLC7UsxIvqZxYoRcZaHD7S"); //type secret key
        StripeCharge stripeCharge = chargeService.Create(myCharge);

        return View();
    }

        public IActionResult Error()
        {
            return View();
        }
    }
}
