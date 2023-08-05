using Sipay_Final.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Entities.DbSets
{
    public class PayInformation:BaseEntity
    {
        public int? GasBill { get; set; }
        public int? ElectricityBill { get; set; }
        public int? WaterBill { get; set; }
        public int? Dues { get; set; }
        public DateTime? BillDuesDate { get; set; } = DateTime.UtcNow;
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
    }
}
