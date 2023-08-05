using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Dtos.MessageAdminToUser
{
    public class MessageToUserResponse
    {
        public string Text { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.New;
        public string AdminName { get; set; }    
    }
}
