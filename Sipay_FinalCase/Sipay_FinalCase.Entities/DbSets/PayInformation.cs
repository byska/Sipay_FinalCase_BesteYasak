using Sipay_FinalCase.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.DbSets
{
    public class PayInformation:AuditableEntity
    {
        public int? GasBill { get; set; }
        public DateTime? GasBillDate { get; set; }
        public int? ElectricityBill { get; set; }
        public DateTime? ElectricityBillDate { get; set; }
        public int? WaterBill { get; set; }
        public DateTime? WaterBillDate { get; set; }
        public int? Dues { get; set; }
        public DateTime? DuesDate { get; set; }
        public Apartment Apartment { get; set; }
    }
}
