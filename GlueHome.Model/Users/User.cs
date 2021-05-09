using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GlueHome.Model.Users
{
    [ExcludeFromCodeCoverage]
    public class User : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        public string Token { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!new EmailAddressAttribute().IsValid(EmailAddress))
            {
                yield return new ValidationResult($"{EmailAddress} is not a valid Email");
            }            
        }
    }
}
