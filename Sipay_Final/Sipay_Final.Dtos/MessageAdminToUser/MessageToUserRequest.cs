using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Dtos.MessageAdminToUser
{
    public class MessageToUserRequest
    {
        public string Text { get; set; }
        public int AdminId { get; set; }
    }
}
