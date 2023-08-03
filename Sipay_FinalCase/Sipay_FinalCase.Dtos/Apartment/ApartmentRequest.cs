using Sipay_FinalCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Sipay_FinalCase.Entities.Enums.Type;

namespace Sipay_FinalCase.Dtos.Apartment
{
    public class ApartmentRequest
    {
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public Resident Resident { get; set; }
        public int? UserId { get; set; }
        public int? GasBill { get; set; }
        public DateTime? GasBillDate { get; set; }
        public int? ElectricityBill { get; set; }
        public DateTime? ElectricityBillDate { get; set; }
        public int? WaterBill { get; set; }
        public DateTime? WaterBillDate { get; set; }
        public int? Dues { get; set; }
        public DateTime? DuesDate { get; set; }
    }
}
