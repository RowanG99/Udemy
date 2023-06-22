using Notely_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Repositories
{
    public interface INoteRepository
    {
        NoteModel FindNoteById(long id);
        IEnumerable<NoteModel> GetAllNotes();
        void SaveNote(NoteModel note);
        void EditNote(NoteModel note);
        void DeleteNote(NoteModel note);
    }
}
