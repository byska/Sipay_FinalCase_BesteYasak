using Sipay_FinalCase.Core.Entities.BaseEntities;
using Sipay_FinalCase.Entities.Enums;
using Type = System.Type;

namespace Sipay_FinalCase.Entities.DbSets
{
    public class Apartment:AuditableEntity
    {
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public Resident Resident { get; set; }
        public User? User { get; set; }
        public PayInformation PayInformation { get; set; }
        public int PayInformationId { get; set; }
    }
}
