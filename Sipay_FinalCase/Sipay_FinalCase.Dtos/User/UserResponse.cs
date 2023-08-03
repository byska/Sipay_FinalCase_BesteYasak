using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Dtos.User
{
    public class UserResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get { return $"{FirstName.ToLower()}_{LastName.ToLower()}"; } }
        public string Tc { get; set; }
        public string Phone { get; set; }
        public string? LicensePlate { get; set; }
    }
}
