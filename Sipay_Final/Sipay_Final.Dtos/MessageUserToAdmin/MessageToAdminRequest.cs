using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Dtos.MessageUserToAdmin
{
    public class MessageToAdminRequest
    {
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}
