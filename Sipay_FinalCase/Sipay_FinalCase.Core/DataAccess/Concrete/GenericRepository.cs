using Microsoft.EntityFrameworkCore;
using Sipay_FinalCase.Core.DataAccess.Abstract;
using Sipay_FinalCase.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sipay_FinalCase.Core.DataAccess.Concrete
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class,IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();

        }
        public async Task<bool> Activate(int id)
        {
            T item = GetByID(id);
            item.IsActive = true;
            return Update(item);
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _table.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (T entity in entities)
                    {
                        _table.AddAsync(entity);
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await _table.AnyAsync(exp);

        public async Task<List<T>> GetActive() => await _table.Where(x => x.IsActive == true).ToListAsync();

        public async Task<IQueryable<T>> GetActivesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _table.Where(x => x.IsActive == true);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<List<T>> GetAllAsync() => await _table.ToListAsync();

        public async Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.Where(exp);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp) => await _table.FirstOrDefaultAsync(exp);

        public T GetByID(int id) => _table.Find(id);

        public IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.Where(x => x.Id == id);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<IEnumerable<T>> GetDefault(Expression<Func<T, bool>> exp) => await _table.Where(exp).ToListAsync();

        public bool Remove(T entity)
        {
            entity.IsActive = false;
            return Update(entity);
        }

        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item = GetByID(id);
                    item.IsActive = false;
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _table.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
