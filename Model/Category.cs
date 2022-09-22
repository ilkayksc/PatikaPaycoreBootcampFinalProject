using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Category
    {   [Required]
        public virtual long Id { get; set; }
        [Required]
        public virtual string CategoryName { get; set; }
        [Required]
        public virtual string CategoryDescription { get; set; }
        public Category()
        {
        }
    }
}

