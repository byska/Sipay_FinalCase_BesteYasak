using Sipay_FinalCase.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.Entities.BaseEntities
{
    public abstract class AuditableEntity : BaseEntity, ISoftDeleteableEntity
    {
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
