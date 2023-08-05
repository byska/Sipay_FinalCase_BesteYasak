using Sipay_Final.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Dtos.PayInformation
{
    public class PayInformationCreditResponse
    {
        public int? GasBill { get; set; }
        public int? ElectricityBill { get; set; }
        public int? WaterBill { get; set; }
        public int? Dues { get; set; }
        public DateTime? BillDuesDate { get; set; } = DateTime.UtcNow;
        public string Block { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
