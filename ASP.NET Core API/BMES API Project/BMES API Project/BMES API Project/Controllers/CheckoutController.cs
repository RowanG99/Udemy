using BMES_API_Project.Messages.Request.Checkout;
using BMES_API_Project.Messages.Response.Checkout;
using BMES_API_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly iCheckoutService _checkoutService;

        public CheckoutController(iCheckoutService iCheckoutService)
        {
            _checkoutService = iCheckoutService; 
        }

        [HttpPost]
        public ActionResult<CheckOutResponse> Checkout(CheckOutRequest checkOutRequest)
        {
            var checkoutResponse = _checkoutService.ProcessCheckout(checkOutRequest);
            return checkoutResponse;
        }
    }
}
