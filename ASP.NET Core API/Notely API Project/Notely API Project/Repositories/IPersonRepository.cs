using Notely_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Repositories
{
    public interface IPersonRepository
    {
        PersonModel FindPersonById(long id);
        IEnumerable<PersonModel> GetAllPeople();
        void SavePerson(PersonModel person);
        void EditPerson(PersonModel person);
        void DeletePerson(PersonModel person);
    }
}
