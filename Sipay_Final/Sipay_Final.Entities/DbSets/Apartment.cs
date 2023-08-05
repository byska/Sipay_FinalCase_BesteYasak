using Sipay_Final.Core.Entities.BaseEntities;
using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Entities.DbSets
{
    public class Apartment:BaseEntity
    {
        public Apartment()
        {
            PayInformations= new HashSet<PayInformation>();
        }
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Enums.Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public Resident Resident { get; set; }
        public User? User { get; set; }
        public ICollection<PayInformation> PayInformations { get; set; }
    }
}
