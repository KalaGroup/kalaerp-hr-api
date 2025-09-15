using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.UserLogin;
using KalaGenset.ERP.HR.Core.ResponseDTO.UserLogin;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class UserLoginServices : IUserLogin
    {
        private readonly KalaDbContext _context;
        private readonly IConfiguration _config;

        public UserLoginServices(KalaDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequest request)
        {
            var user = await _context.UserLogins
                .Include(u => u.UserLoginEmployee) // join with employee
                .FirstOrDefaultAsync(u =>
                    (u.UserLoginEmployeeId.ToString() == request.Username
                     || u.UserLoginEmployee.EmployeeMasterFirstName == request.Username)
                     && u.PasswordHash == request.Password); // ⚠️ plain text for temp use

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            // Generate JWT token
            var token = await GenerateTokenAsync(user);

            return new LoginResponseDTO
            {
                AccessToken = token,
                TokenType = "bearer",
                ExpiresIn = 3600,
                UserId = user.UserId,  // ⚠️ here you wrote `user.UserID` (capital D) in your paste – check spelling
                EmployeeId = user.UserLoginEmployeeId,
                FullName = $"{user.UserLoginEmployee.EmployeeMasterFirstName} {user.UserLoginEmployee.EmployeeMasterLastName}",
                // FullName = user.UserLoginEmployee.EmployeeMasterFullName,
                // Email = $"{user.UserLoginEmployee.EmployeeMasterFullName}@company.com"
                Email = "Admin@kalabiz.com",
                ProfilePictureURL = user.ProfilePictureUrl ?? "/images/kala-logo.png"
            };
        }

        public Task<string> GenerateTokenAsync(UserLogin user)
        {
            // ✅ secret key from appsettings.json
            var secretKey = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim("employeeId", user.UserLoginEmployeeId.ToString()),
            new Claim("fullName", user.UserLoginEmployee.EmployeeMasterFullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                 expires: DateTime.UtcNow.AddHours(1),   // expires in 1 hour
               // expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(tokenString);
        }
    }
}
