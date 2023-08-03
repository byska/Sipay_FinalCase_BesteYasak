using Microsoft.EntityFrameworkCore;
using Serilog;
using Sipay_FinalCase.Core.DataAccess.Abstract;
using Sipay_FinalCase.Core.DataAccess.Concrete;
using Sipay_FinalCase.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Core.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly DbContext _dbContext;
        public Uow(DbContext dbContext)
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
