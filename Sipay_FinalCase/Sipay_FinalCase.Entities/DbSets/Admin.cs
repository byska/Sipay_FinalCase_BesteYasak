using Sipay_FinalCase.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.DbSets
{
    public class Admin:BaseUser
    {
        public ICollection<MessageAdminToUser> MessageAdminToUsers { get; set; }
        public ICollection<MessageUserToAdmin> MessageUserToAdmins { get; set; }
    }
}
