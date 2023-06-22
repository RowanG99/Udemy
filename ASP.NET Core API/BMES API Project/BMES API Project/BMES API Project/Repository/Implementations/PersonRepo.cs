using BMES_API_Project.Database;
using BMES_API_Project.Models.Shared;
using System.Collections.Generic;

namespace BMES_API_Project.Repository.Implementations
{
    public class PersonRepo : iPersonRepo
    {
        private dbContext _dbContext;

        public PersonRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeletePerson(Person person)
        {
            _dbContext.Remove(person);
            _dbContext.SaveChanges();
        }

        public Person FindPersonById(long id)
        {
            var person = _dbContext.People.Find(id);
            return person; 
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = _dbContext.People;
            return people; 
        }

        public void SavePerson(Person person)
        {
            _dbContext.Add(person);
            _dbContext.SaveChanges();
        }

        public void UpdatePerson(Person perosn)
        {
            _dbContext.Update(perosn);
            _dbContext.SaveChanges();
        }
    }
}
