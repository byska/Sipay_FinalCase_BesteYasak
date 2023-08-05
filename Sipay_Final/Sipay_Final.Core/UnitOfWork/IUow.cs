using Sipay_Final.Core.DataAccess.Abstract;
using Sipay_Final.Core.Entities.Interfaces;
using System.Transactions;

namespace Sipay_Final.Core.UnitOfWork
{
    public interface IUow
    {
        void Complete();
        void CompleteWithTransaction();
        IGenericRepository<T> GetRepository<T>() where T : class,IEntity;
    }
}
