﻿namespace Maripiell.Services.CouponAPI.Domain.Contracts
{
    public interface IAudityEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
