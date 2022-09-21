using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Buy
    {
        public virtual long Id { get; set; }
        public virtual double Price { get; set; }
        public virtual long ProductOwner { get; set; }
        public virtual long Customer { get; set; }
        public virtual long ProductId { get; set; }
        public Buy()
        {
        }
    }
}

