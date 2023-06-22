using Microsoft.EntityFrameworkCore;
using Notely_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_API_Project.Database
{
    public class NotelyAPIDbContext :DbContext
    {
        public NotelyAPIDbContext(DbContextOptions<NotelyAPIDbContext> options) : base(options) { }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<PersonModel> People { get; set; }
    }
}
