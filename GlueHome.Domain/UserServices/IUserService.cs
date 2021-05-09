using GlueHome.Model.Users;
using System.Threading.Tasks;

namespace GlueHome.Domain.UserServices
{
    public interface IUserService
    {
        Task<Login> GetUser(string EmailAddress, string Password);
    }
}
