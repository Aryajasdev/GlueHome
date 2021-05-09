using System.Diagnostics.CodeAnalysis;

namespace GlueHome.Model.Users
{
    [ExcludeFromCodeCoverage]
    public class Login
    {
        public int Id { get; set; }

        public string Token { get; set; }
    }
}
