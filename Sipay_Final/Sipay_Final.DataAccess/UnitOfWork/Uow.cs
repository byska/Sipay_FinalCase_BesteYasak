using Microsoft.EntityFrameworkCore;
using Serilog;
using Sipay_Final.DataAccess.Context;
using Sipay_Final.DataAccess.DataAccess.Abstract;
using Sipay_Final.DataAccess.DataAccess.Concrete;

namespace Sipay_Final.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly FinalDbContext _dbContext;
        public Uow(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    Log.Error(ex, "CompleteWithTransaction");
                }
            }
        }

        IGenericRepository<T> IUow.GetRepository<T>()
        {
            return new GenericRepository<T>(_dbContext);
        }

        
    }
}
