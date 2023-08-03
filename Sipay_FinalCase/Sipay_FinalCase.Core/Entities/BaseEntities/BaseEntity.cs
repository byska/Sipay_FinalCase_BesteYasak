using Sipay_FinalCase.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.Entities.BaseEntities
{
    public abstract class BaseEntity : IUpdateableEntity
    {
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
