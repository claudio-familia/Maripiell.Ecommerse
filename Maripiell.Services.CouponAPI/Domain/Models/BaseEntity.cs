using Maripiell.Services.CouponAPI.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Maripiell.Services.CouponAPI.Domain.Models
{
    public class BaseEntity: IAudityEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        
        [Required]
        public int UpdatedBy { get; set;}
        
        [Required]
        public DateTime CreatedDate { get; set;}
        
        [Required]
        public DateTime UpdatedDate { get; set;}

        [Required]
        public bool IsDeleted { get; set; }
        

    }
}
