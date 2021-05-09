using GlueHome.Data.Context;
using GlueHome.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GlueHome.Domain.UserServices
{
    public class UserService : IUserService
    {
        private readonly DeliveryContext _context;
        private readonly AppSettings appSettings;

        public UserService(IOptions<AppSettings> options, DeliveryContext context)
        {
            _context = context;
            appSettings = options.Value;
        }

        public async Task<Login> GetUser(string EmailAddress, string Password)
        {            
            var user = await _context.Users.Include("Role").Where(x => 
                x.EmailAddress == EmailAddress && 
                x.Password == Password).SingleOrDefaultAsync();

            if (user == null)
                return null;

            var login = new Login
            {
                Id = user.Id
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            login.Token = tokenHandler.WriteToken(token);
                        
            return login;
        }
    }
}
