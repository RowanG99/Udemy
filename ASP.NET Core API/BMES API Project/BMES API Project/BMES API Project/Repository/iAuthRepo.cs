using BMES_API_Project.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository
{
    public interface iAuthRepo
    {
        Task<IdentityResult> RegisterAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<bool> LogInAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<User> FindAsync(string request, CancellationToken cancellationToken);
        Task<IList<string>> FindUserRolesAsync(string email, CancellationToken cancellationToken);
    }
}
