using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.UserLogin;
using KalaGenset.ERP.HR.Core.ResponseDTO.UserLogin;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IUserLogin
    {
        public Task<LoginResponseDTO> LoginAsync(LoginRequest request);
    }
}
