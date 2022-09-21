using System;
using System.ComponentModel.DataAnnotations;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampFinalProject.Dto

{
    public class ProductDto
    {
        [Required]
        public virtual long Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public virtual string ProductName { get; set; }

        [Required]
        [StringLength(maximumLength: 500)]
        public virtual string ProductDescription { get; set; }

        [Required]
        public virtual long CategoryId { get; set; }

        [Required]
        public virtual int Color { get; set; }

        [Required]
        public virtual double Price { get; set; }

        [Required]
        public virtual int Brand { get; set; }

        [Required]
        public virtual bool IsOfferable { get; set; }

        [Required]
        public virtual bool IsSold { get; set; }

        [Required]
        public virtual long ProductOwner { get; set; }

        public ProductDto()
        {
        }
    }
}

