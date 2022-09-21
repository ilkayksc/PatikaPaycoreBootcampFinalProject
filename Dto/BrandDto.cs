using System;
using System.ComponentModel.DataAnnotations;

namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class BrandDto
    {
        [Required]
        public virtual long Id { get; set; }
        [Required]
        public virtual string BrandShortName { get; set; }
        [Required]
        public virtual string BrandName { get; set; }
        public BrandDto()
        {
        }
    }
}

