using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonEmail { get; set; }
#nullable enable
        public ICollection<NoteModel>? Notes { get; set; }
    }
}
