using PayInformationModel = Sipay_Final.Entities.DbSets;



namespace Sipay_Final.Business.Services.Email
{ 
    public interface IEmailService 
    {
        Task SendReminder(string ToEmail, int? waterBill,int? electricityBill,int? gasBill,int? dues);
    }
}
