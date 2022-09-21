using System;
using System.ComponentModel.DataAnnotations;

namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class TokenRequest
    {
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        public virtual string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public virtual string Password { get; set; }
       
        public TokenRequest()
        {
        }
    }
}

