using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Buy
    {   [Required]
        public virtual long Id { get; set; }
        [Required]
        public virtual double Price { get; set; }
        public virtual long ProductOwner { get; set; }
        public virtual long Customer { get; set; }
        [Required]
        public virtual long ProductId { get; set; }
        public Buy()
        {
        }
    }
}

