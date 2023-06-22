using BMES_API_Project.Models.Shared;
using System.Collections.Generic;

namespace BMES_API_Project.Repository
{
    public interface iPersonRepo
    {
        Person FindPersonById(long id);
        IEnumerable<Person> GetAllPeople();
        void SavePerson(Person person);
        void UpdatePerson(Person perosn);
        void DeletePerson(Person person); 
    }
}
