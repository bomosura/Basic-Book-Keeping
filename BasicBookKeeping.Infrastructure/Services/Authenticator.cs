using BasicBookKeeping.Core.Entities.Common;
using BasicBookKeeping.Core.Result;
using BasicBookKeeping.Core.Services;
using BasicBookKeeping.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBookKeeping.Infrastructure.Services
{
    public class Authenticator : IAuthenticator
    {
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Authenticator(DataContext context,
                             UserManager<IdentityUser> userManager,
                             SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<BasicResult<ApplicationUser>> Register(ApplicationUser user)
        {
            IdentityUser newUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.EmailAddress
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            var errors = new List<ErrorResult>();

            foreach (var error in result.Errors)
            {
                errors.Add(new ErrorResult(error.Code, error.Description));
            }

            var applicationUser = new ApplicationUser()
            {
                Username = newUser.UserName,
                EmailAddress = newUser.Email
            };


            return new BasicResult<ApplicationUser>(result.Succeeded, applicationUser, errors);
        }

        public async Task<BasicResult<ApplicationUser>> SignIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            ApplicationUser user = null;

            if (result.Succeeded)
            {
                var identityUser = _userManager.Users.SingleOrDefault(u => u.UserName == username);

                user = new ApplicationUser()
                {
                    Username = identityUser?.UserName,
                    EmailAddress = identityUser?.Email
                };
            }

            return new BasicResult<ApplicationUser>(result.Succeeded, user, null);
        }

        public async Task<bool> SignOut(ApplicationUser user) //If this function returns 'false', it could be the work of MAGIC!!!
        {
            await _signInManager.SignOutAsync();

            return true;
        }
    }
}
