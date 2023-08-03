using Sipay_FinalCase.Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.Entities.Interfaces
{
    public interface IBaseUser
    {
         string Firstname { get; set; }
         string Lastname { get; set; }
         string Email { get; set; } 
         string Username { get { return $"{Firstname.ToLower()}_{Lastname.ToLower()}"; } }
         string Password { get; set; }
         DateTime? LastActivity { get; set; }
    }
}
