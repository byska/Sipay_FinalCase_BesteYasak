﻿using Sipay_FinalCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Dtos.MessageUserToAdmin
{
    public class MessageUserToAdminRequest
    {
        public string Text { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.New;
        public int AdminId { get; set; }
    }
}
