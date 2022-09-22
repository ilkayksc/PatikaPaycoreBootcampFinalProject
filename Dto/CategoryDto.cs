using System;
namespace PatikaPaycoreBootcampFinalProject.Dto
{
    public class CategoryDto
    {   [Required]
        public virtual long Id { get; set; }
        [Required]
        public virtual string CategoryName { get; set; }
        [Required]
        public virtual string CategoryDescription { get; set; }
        
        public CategoryDto()
        {
        }
    }
}

