using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.Core.Entities.Enums;
using Sipay_Final.Core.Entities.Interfaces;
using Sipay_Final.Core.Utilities.Helpers;

namespace Sipay_Final.Core.Entities.BaseEntities
{
    public class BaseUser:BaseEntity, IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        private string _password;
        public string? Password { get { return _password; } set { _password = StringGenerator.GenerateRandomPassword(); } }
        public DateTime? LastActivity { get; set; }
        public Role Role { get; set; }
    }
}
