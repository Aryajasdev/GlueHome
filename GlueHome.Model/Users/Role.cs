using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GlueHome.Model.Users
{
    [ExcludeFromCodeCoverage]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
