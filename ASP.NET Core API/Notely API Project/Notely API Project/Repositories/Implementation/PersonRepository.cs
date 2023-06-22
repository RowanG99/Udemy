using Notely_API_Project.Database;
using Notely_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Repositories.Implementation
{
    public class PersonRepository:IPersonRepository
    {
        private NotelyAPIDbContext _context; 

        public PersonRepository(NotelyAPIDbContext context)
        {
            _context = context;
        }

        public PersonModel FindPersonById(long id)
        {
            var note = _context.People.Find(id);
            return note;
        }

        public IEnumerable<PersonModel> GetAllPeople()
        {
            var notes = _context.People;
            return notes;
        }

        public void SavePerson(PersonModel person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void EditPerson(PersonModel person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(PersonModel person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
