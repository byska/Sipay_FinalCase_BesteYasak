using Sipay_Final.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Entities.DbSets
{
    public class Admin:BaseUser
    {
        public Admin()
        {
            IncomingToAdmin = new HashSet<MessageToAdmin>();
        }
        public ICollection<MessageToAdmin> IncomingToAdmin { get; set; }

    }
}
