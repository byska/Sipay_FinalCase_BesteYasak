using PayInformationModel = Sipay_Final.Entities.DbSets;



namespace Sipay_Final.Business.Services.Email
{ 
    public interface IEmailService 
    {
        Task SendResetPasswordEmail(string ToEmail, PayInformationModel.PayInformation payInformation);
    }
}
