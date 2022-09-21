using System;
namespace PatikaPaycoreBootcampFinalProject.Dto
{
    public class CategoryDto
    {
        public virtual long Id { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string CategoryDescription { get; set; }
        
        public CategoryDto()
        {
        }
    }
}

