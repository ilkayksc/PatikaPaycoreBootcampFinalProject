using System;
using System.ComponentModel.DataAnnotations;

namespace PatikaPaycoreBootcampFinalProject.Dto
{
    public class OfferDto
    {
        [Required]
        public virtual long Id { get; set; }

        [Required]
        public virtual long ProductId { get; set; }

        [Required]
        public virtual double Price { get; set; }

        [Required]
        public virtual long Customer { get; set; }

        [Required]
        public virtual bool IsAccept { get; set; }


        public OfferDto()
        {
        }
    }
}