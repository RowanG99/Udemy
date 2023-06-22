using BMES_API_Project.Messages.DTOs.Address;
using BMES_API_Project.Messages.DTOs.Cart;
using BMES_API_Project.Messages.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Checkout
{
    public class CheckOutRequest
    {
        public CustomerDTO Customer { get; set; }
        public AddressDTO Address { get; set; }
        public CartDTO Cart { get; set; }
    }
}
