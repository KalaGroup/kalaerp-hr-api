using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.UserLogin
{
    public class LoginRequest
    {
        public string Username { get; set; }  // Can be email or employee code
        public string Password { get; set; }
    }
}
