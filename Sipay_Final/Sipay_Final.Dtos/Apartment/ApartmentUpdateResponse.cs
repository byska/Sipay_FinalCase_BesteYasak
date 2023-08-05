namespace Sipay_Final.Dtos.Apartment
{
    public class ApartmentUpdateResponse:ApartmentResponse
    {
        public int Id { get; set; }
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
