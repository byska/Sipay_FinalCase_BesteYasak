using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Dtos.PayInformation
{
    public class PayInformationRequest
    {
        public int? GasBill { get; set; }
        public DateTime? GasBillDate { get; set; }
        public int? ElectricityBill { get; set; }
        public DateTime? ElectricityBillDate { get; set; }
        public int? WaterBill { get; set; }
        public DateTime? WaterBillDate { get; set; }
        public int? Bill { get; set; }
        public DateTime? BillDate { get; set; }
        public int ApartmentId { get; set; }
    }
}
