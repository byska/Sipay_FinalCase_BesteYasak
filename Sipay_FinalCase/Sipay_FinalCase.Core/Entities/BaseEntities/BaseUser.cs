using Microsoft.AspNetCore.Identity;
using Sipay_FinalCase.Core.Entities.Interfaces;
using Sipay_FinalCase.Core.Utilities.Helpers;

namespace Sipay_FinalCase.Core.Entities.BaseEntities
{
    public abstract class BaseUser : AuditableEntity, IBaseUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        private string _password;
       public string Password { get { return _password; } set { _password = StringGenerator.GenerateRandomPassword(); } }
       
        public DateTime? LastActivity { get; set; }
    }
}
