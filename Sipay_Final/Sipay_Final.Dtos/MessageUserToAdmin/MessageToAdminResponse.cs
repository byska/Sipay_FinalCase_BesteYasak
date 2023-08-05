using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Dtos.MessageUserToAdmin
{
    public class MessageToAdminResponse
    {
        public string Text { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.New;
        public string UserName { get; set; }
    }
}
