using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GlueHome.Model.Users
{
    [ExcludeFromCodeCoverage]
    public class SignIn
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
