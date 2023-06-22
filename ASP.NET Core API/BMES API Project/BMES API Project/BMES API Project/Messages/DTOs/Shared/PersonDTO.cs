using BMES_API_Project.Models.Shared;
using System;

namespace BMES_API_Project.Messages.DTOs.Shared
{
    public class PersonDTO
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
    }
}
