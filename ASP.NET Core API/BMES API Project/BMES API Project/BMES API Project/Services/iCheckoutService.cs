using BMES_API_Project.Messages.Response.Checkout;
using BMES_API_Project.Messages.Request.Checkout;

namespace BMES_API_Project.Services
{
    public interface iCheckoutService
    {
        CheckOutResponse ProcessCheckout(CheckOutRequest checkoutRequest);
    }
}
