using Sipay_FinalCase.Core.Entities.BaseEntities;
using Sipay_FinalCase.Entities.Abstract;
using Sipay_FinalCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.DbSets
{
    public class Message :  AuditableEntity, IMessage
    {
        public string Text { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.New;
    }
}
