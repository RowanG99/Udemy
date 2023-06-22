using Notely_API_Project.Database;
using Notely_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private NotelyAPIDbContext _context; 

        public NoteRepository(NotelyAPIDbContext context)
        {
            _context = context;
        }

        public NoteModel FindNoteById(long id)
        {
            var note = _context.Notes.Find(id);
            return note; 
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {
            var notes = _context.Notes;
            return notes;
        }
        public void SaveNote(NoteModel note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        } 

        public void EditNote(NoteModel note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges(); 
        }

        public void DeleteNote(NoteModel note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}
