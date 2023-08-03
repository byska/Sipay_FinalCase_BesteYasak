using Sipay_FinalCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Dtos.Apartment
{
    public class ApartmentResponse
    {
        public Block Block { get; set; }
        public ApartmentStatus Status { get; set; }
        public Entities.Enums.Type Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public Resident Resident { get; set; }
        public string UserName { get; set; }
        
    }
}
