using System;
using System.Collections.Generic;
using BMES_API_Project.Messages.DTOs.Address;
using BMES_API_Project.Messages.DTOs.Order;


namespace BMES_API_Project.Messages.DTOs.Customer
{
    public class CustomerDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Sex { get; set; }
        public string DateOfBirth { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool isDeleted { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }
    }
}
