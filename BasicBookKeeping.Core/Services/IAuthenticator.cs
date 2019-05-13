using BasicBookKeeping.Core.Entities.Common;
using BasicBookKeeping.Core.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicBookKeeping.Core.Services
{
    public interface IAuthenticator
    {
        Task<BasicResult<ApplicationUser>> Register(ApplicationUser user);
        Task<BasicResult<ApplicationUser>> SignIn(string username, string password);
        Task<bool> SignOut(ApplicationUser user);
    }
}
