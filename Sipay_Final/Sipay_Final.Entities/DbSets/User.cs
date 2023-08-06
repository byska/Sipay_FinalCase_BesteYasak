using Sipay_Final.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Entities.DbSets
{
    public class User:BaseUser
    {
        public User()
        {
            IncomingToUser=new HashSet<MessageToUser>();
        }
        public string Tc { get; set; }
        public string Phone { get; set; }
        public string? LicensePlate { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
        public ICollection<MessageToUser> IncomingToUser { get; set; }

    }
}
