using BMES_API_Project.Models.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Database
{
    public class IdentitydbContext:IdentityDbContext<User>
    {
        public IdentitydbContext(DbContextOptions<IdentitydbContext>options) : base(options) { }
    }
}
