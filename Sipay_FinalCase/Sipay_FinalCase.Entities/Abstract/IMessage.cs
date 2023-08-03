using Sipay_FinalCase.Entities.DbSets;
using Sipay_FinalCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.Abstract
{
    public interface IMessage
    {
        public string Text { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }//From
        public User User { get; set; }
        public int UserId { get; set; }
        public MessageStatus Status { get; set; }
    }
}
