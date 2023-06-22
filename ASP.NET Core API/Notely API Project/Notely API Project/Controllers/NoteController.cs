using Microsoft.AspNetCore.Http;
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
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository; 
        }

        [HttpGet(template:"{id}")]
        public ActionResult<NoteModel> GetNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            return note;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteModel>> GetNotes()
        {
            var notes = _noteRepository.GetAllNotes().ToList();
            return notes;
        }

        [HttpPost]
        public ActionResult<NoteModel> PostNote(NoteModel note)
        {
            var currentDate = DateTime.Now;
            note.DateCreated = currentDate;
            note.DateModified = currentDate;
            _noteRepository.SaveNote(note);
            return note;
        }

        [HttpPut]
        public ActionResult<NoteModel> PutNote(NoteModel note)
        {
            note.DateModified = DateTime.Now;
            _noteRepository.DeleteNote(note);
            return note;
        }

        [HttpDelete(template:"{id}")]
        public ActionResult<NoteModel> DeleteNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            _noteRepository.DeleteNote(note);
            return note;
        }
    }
}
