using BMES_API_Project.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository
{
    public interface iAddressRepo
    {
        public Address FindAddressById(long id);
        public IEnumerable<Address> GetAllAddresses();
        public void SaveAddress(Address address);
        public void UpdateAddress(Address address);
        public void DeleteAddress(Address address); 

    }
}
