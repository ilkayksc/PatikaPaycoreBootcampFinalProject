using System;
using System.ComponentModel.DataAnnotations;

namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Account
    {
        [Required]
        public virtual long Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public virtual string Surname { get; set; }
        public virtual string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        [StringLength(maximumLength: 100,MinimumLength =10)]
        public virtual string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public virtual string Password { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime LastActivity { get;  set; }

        public Account() { }

        
    }
}

