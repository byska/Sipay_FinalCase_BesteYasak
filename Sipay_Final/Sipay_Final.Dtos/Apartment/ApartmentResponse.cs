using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Dtos.Apartment
{
    public class ApartmentResponse
    {
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Entities.Enums.Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public Resident Resident { get; set; }
        public string UserName { get; set; }
        
    }
}
