using BMES_API_Project.Database;
using BMES_API_Project.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BMES_API_Project.Repository.Implementations
{
    public class AddressRepo : iAddressRepo
    {
        private dbContext _dbContext;

        public AddressRepo(dbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void DeleteAddress(Address address)
        {
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
        }

        public Address FindAddressById(long id)
        {
            var address = _dbContext.Addresses.Find(id);
            return address; 
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = _dbContext.Addresses;
            return addresses; 
        }

        public void SaveAddress(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _dbContext.Addresses.Update(address);
            _dbContext.SaveChanges();
        }
    }
}
