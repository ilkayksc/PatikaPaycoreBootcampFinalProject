using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class ColorDto
    {   [Required]
        public virtual long Id { get; set; }
        [Required]
        public virtual string ColorName { get; set; }
        [Required]
        public virtual string ColorCode { get; set; }
        public ColorDto()
        {
        }
    }
}

