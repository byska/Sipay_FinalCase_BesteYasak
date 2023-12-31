﻿using Sipay_Final.Entities.Enums;
using Type = Sipay_Final.Entities.Enums.Type;

namespace Sipay_Final.Dtos.Apartment
{
    public class ApartmentRequest
    {
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public int? GasBill { get; set; }
        public int? ElectricityBill { get; set; }
        public int? WaterBill { get; set; }
        public int? Dues { get; set; }
        public DateTime? BillDuesDate { get; set; } = DateTime.UtcNow;

    }
}
