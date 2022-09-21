using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Brand
    {
        public virtual long Id { get; set; }
        public virtual string BrandShortName { get; set; }
        public virtual string BrandName { get; set; }
        public Brand()
        {
        }
    }
}

