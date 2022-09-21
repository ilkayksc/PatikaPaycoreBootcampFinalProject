using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Category
    {   public virtual long Id { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string CategoryDescription { get; set; }
        public Category()
        {
        }
    }
}

