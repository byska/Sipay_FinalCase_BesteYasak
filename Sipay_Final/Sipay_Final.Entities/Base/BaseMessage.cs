using Sipay_Final.Core.Entities.BaseEntities;
using Sipay_Final.Core.Entities.Interfaces;
using Sipay_Final.Entities.DbSets;
using Sipay_Final.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Entities.Base
{
    public class BaseMessage:BaseEntity
    {
        public string Text { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.New;
    }
}
