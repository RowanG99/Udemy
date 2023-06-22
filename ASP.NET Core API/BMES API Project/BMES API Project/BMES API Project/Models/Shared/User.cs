using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Models.Shared
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
    }
}
