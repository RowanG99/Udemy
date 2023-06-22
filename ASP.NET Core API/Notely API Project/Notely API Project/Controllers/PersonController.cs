using Microsoft.AspNetCore.Mvc;
using Notely_API_Project.Models;
using Notely_API_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository; 

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet(template:"{id}")]
        public ActionResult<PersonModel> GetPerson(long id)
        {
            var person = _personRepository.FindPersonById(id); 
            return person;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> GetPeople()
        {
            var people = _personRepository.GetAllPeople().ToList();
            return people; 
        }

        [HttpPost]
        public ActionResult<PersonModel> PostPerson (PersonModel person)
        {
            _personRepository.SavePerson(person);
            return person;
        }

        [HttpDelete(template:"{id}")]
        public ActionResult<PersonModel> DeleteNote(long id)
        {
            var note = _personRepository.FindPersonById(id);
            _personRepository.DeletePerson(note);
            return note;
        }
    }
}
