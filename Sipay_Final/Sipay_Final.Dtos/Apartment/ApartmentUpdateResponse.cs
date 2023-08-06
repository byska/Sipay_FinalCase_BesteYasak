namespace Sipay_Final.Dtos.Apartment
{
    public class ApartmentUpdateResponse:ApartmentResponse
    {
        public int Id { get; set; }
        public int? GasBill { get; set; }
        public int? ElectricityBill { get; set; }
        public int? WaterBill { get; set; }
        public int? Dues { get; set; }
        public DateTime? BillDuesDate { get; set; } = DateTime.UtcNow;

    }
}
