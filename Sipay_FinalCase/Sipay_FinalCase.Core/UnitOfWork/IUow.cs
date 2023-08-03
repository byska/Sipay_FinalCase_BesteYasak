using Sipay_FinalCase.Core.DataAccess.Abstract;
using Sipay_FinalCase.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.UnitOfWork
{
    public interface IUow
    {
        void Complete();
        void CompleteWithTransaction();
        IGenericRepository<T> GetRepository<T>() where T : class,IEntity;
    }
}
