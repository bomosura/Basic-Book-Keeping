using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBookKeeping.Core.Entities.Common
{
    public class ApplicationUser
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }
}
