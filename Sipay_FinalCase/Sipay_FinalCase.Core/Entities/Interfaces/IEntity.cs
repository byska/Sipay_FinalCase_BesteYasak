using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.Entities.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsActive { get; set; }
    }
}
