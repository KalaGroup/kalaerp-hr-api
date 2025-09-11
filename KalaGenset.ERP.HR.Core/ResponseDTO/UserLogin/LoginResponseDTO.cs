using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.UserLogin
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        // Additional user info
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfilePictureURL { get; set; }
    }
}
