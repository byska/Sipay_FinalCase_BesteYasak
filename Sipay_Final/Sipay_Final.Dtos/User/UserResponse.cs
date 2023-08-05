using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Dtos.User
{
    public class UserResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Tc { get; set; }
        public string Phone { get; set; }
        public string? LicensePlate { get; set; }
    }
}
