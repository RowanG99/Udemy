﻿using BMES_API_Project.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class AuthRepo:iAuthRepo
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthRepo(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRole.RegisteredUser.ToString());
            }

            return result;
        }

        public async Task<bool> LogInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, false, false);
            return result.Succeeded;
        }

        public async Task<User> FindAsync(string request, CancellationToken cancellationToken)
        {
            return await _userManager
                .Users
                .FirstOrDefaultAsync(u => u.Email == request, cancellationToken);
        }

        public async Task<IList<string>> FindUserRolesAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager
                .Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            var roles = await _userManager.GetRolesAsync(user);

            return roles;
        }
    }
}
