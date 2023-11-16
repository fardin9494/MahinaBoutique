using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Application.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PaymentResult Result { get; set; }

        public void OnGet(PaymentResult result)
        {
            Result = result;
        }
    }
}
