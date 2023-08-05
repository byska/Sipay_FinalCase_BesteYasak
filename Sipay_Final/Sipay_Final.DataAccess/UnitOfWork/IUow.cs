using Sipay_Final.Core.Entities.Interfaces;
using Sipay_Final.DataAccess.DataAccess.Abstract;

namespace Sipay_Final.DataAccess.UnitOfWork
{
    public interface IUow
    {
        void Complete();
        void CompleteWithTransaction();
        IGenericRepository<T> GetRepository<T>() where T : class,IEntity;
    }
}
