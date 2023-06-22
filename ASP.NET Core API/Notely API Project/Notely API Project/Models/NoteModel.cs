using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Models
{
    public class NoteModel
    {
        [Key]
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public long PersonId { get; set; }
        public PersonModel Person { get; set; }
    }
}
