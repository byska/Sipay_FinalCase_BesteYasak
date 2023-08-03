using Sipay_FinalCase.Core.Utilities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Business.Services.Generic
{
    public interface IGenericService<TEntity,TRequest,TResponse>
    {
        Task<ApiResponse<bool>> Activate(int id);
        Task<ApiResponse<bool>> Add(TRequest entity);
        Task<ApiResponse<bool>> AddRangeAsync(List<TRequest> entities);
        Task<ApiResponse<bool>> Any(Expression<Func<TEntity, bool>> exp);
        Task<ApiResponse<List<TResponse>>> GetActive();
        Task<ApiResponse<List<TResponse>>> GetAll();
        Task<ApiResponse<IQueryable<TResponse>>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<ApiResponse<IQueryable<TResponse>>> GetAll(Expression<Func<TEntity, bool>> exp, params Expression<Func<TEntity, object>>[] includes);
        Task<ApiResponse<TResponse>> GetByDefault(Expression<Func<TEntity, bool>> exp);
        ApiResponse<TResponse> GetById(int id);
        ApiResponse<IQueryable<TResponse>> GetById(int id, params Expression<Func<TEntity, object>>[] includes);
        ApiResponse<bool> Remove(TEntity entity);
        ApiResponse<bool> Remove(int id);
        ApiResponse<bool> Update(TRequest entity,int id);
    }
}
