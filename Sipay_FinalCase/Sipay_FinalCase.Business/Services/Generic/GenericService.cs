using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Serilog;
using Sipay_FinalCase.Core.Entities.BaseEntities;
using Sipay_FinalCase.Core.Entities.Interfaces;
using Sipay_FinalCase.Core.UnitOfWork;
using Sipay_FinalCase.Core.Utilities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Business.Services.Generic
{
    public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : BaseEntity
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GenericService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public virtual async Task<ApiResponse<bool>> Activate(int id)
        {
            try
            {
                if (id == 0 || _uow.GetRepository<TEntity>().GetByID(id) == null)
                    return new ApiResponse<bool>(false);
                else
                    return new ApiResponse<bool>(await _uow.GetRepository<TEntity>().Activate(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Activate");
                return new ApiResponse<bool>(false);
            }

        }

        public virtual async Task<ApiResponse<bool>> Add(TRequest request)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(request);
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = "admin";

                var result = await _uow.GetRepository<TEntity>().Add(entity);
                _uow.Complete();
                return new ApiResponse<bool>(result);


            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Add");
                return new ApiResponse<bool>(false);
            }
        }

        public virtual async Task<ApiResponse<bool>> AddRangeAsync(List<TRequest> requests)
        {
            try
            {
                List<TEntity> entities = _mapper.Map<List<TEntity>>(requests);
                foreach (var request in entities)
                {
                    request.CreatedDate = DateTime.Now;
                    request.CreatedBy = "admin";
                }

                var result = await _uow.GetRepository<TEntity>().AddRangeAsync(entities);
                _uow.CompleteWithTransaction();
                return new ApiResponse<bool>(result);


            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.AddRange");
                return new ApiResponse<bool>(false);
            }
        }

        public virtual async Task<ApiResponse<bool>> Any(Expression<Func<TEntity, bool>> exp)
        {
            try
            {
                return new ApiResponse<bool>(await _uow.GetRepository<TEntity>().Any(exp));
            }
            catch (Exception ex)
            {

                Log.Error(ex, "GenericService.Any");
                return new ApiResponse<bool>(false);
            }
        }

        public virtual async Task<ApiResponse<List<TResponse>>> GetActive()
        {
            try
            {
                List<TEntity> entities = await _uow.GetRepository<TEntity>().GetActive();
                List<TResponse> responses = _mapper.Map<List<TResponse>>(entities);
                return new ApiResponse<List<TResponse>>(responses);
            }
            catch (Exception ex)
            {

                Log.Error(ex, "GenericService.GetActive");
                return new ApiResponse<List<TResponse>>(ex.Message);
            }
        }

        public virtual async Task<ApiResponse<List<TResponse>>> GetAll()
        {
            try
            {
                var result = await _uow.GetRepository<TEntity>().GetAllAsync();
                var response = _mapper.Map<List<TResponse>>(result);
                return new ApiResponse<List<TResponse>>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetAll");
                return new ApiResponse<List<TResponse>>(ex.Message);
            }
        }

        public virtual async Task<ApiResponse<IQueryable<TResponse>>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                var result = await _uow.GetRepository<TEntity>().GetAllAsync(includes);
                var response = _mapper.Map<IQueryable<TResponse>>(result);
                return new ApiResponse<IQueryable<TResponse>>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetAll");
                return new ApiResponse<IQueryable<TResponse>>(ex.Message);
            }
        }

        public virtual async Task<ApiResponse<IQueryable<TResponse>>> GetAll(Expression<Func<TEntity, bool>> exp, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                var result = await _uow.GetRepository<TEntity>().GetAllAsync(exp, includes);
                var response = _mapper.Map<IQueryable<TResponse>>(result);
                return new ApiResponse<IQueryable<TResponse>>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetAll");
                return new ApiResponse<IQueryable<TResponse>>(ex.Message);
            }
        }

        public virtual async Task<ApiResponse<TResponse>> GetByDefault(Expression<Func<TEntity, bool>> exp)
        {

            try
            {
                var result = await _uow.GetRepository<TEntity>().GetByDefault(exp);
                var response = _mapper.Map<TResponse>(result);
                return new ApiResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetByDefault");
                return new ApiResponse<TResponse>(ex.Message);
            }
        }

        public virtual ApiResponse<TResponse> GetById(int id)
        {
            try
            {
                var result = _uow.GetRepository<TEntity>().GetByID(id);
                var response = _mapper.Map<TResponse>(result);
                return new ApiResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetById");
                return new ApiResponse<TResponse>(ex.Message);
            }
        }

        public virtual ApiResponse<IQueryable<TResponse>> GetById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                var result = _uow.GetRepository<TEntity>().GetByID(id,includes);
                IQueryable<TResponse> response = _mapper.Map<IQueryable<TResponse>>(result);
                return new ApiResponse<IQueryable<TResponse>>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetById");
                return new ApiResponse<IQueryable<TResponse>>(ex.Message);
            }
        }



        public virtual ApiResponse<bool> Remove(TEntity entity)
        {
            try
            {
                var result = _uow.GetRepository<TEntity>().Remove(entity);
                return new ApiResponse<bool>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Remove");
                return new ApiResponse<bool>(ex.Message);
            }
        }

        public virtual ApiResponse<bool> Remove(int id)
        {
            try
            {
                TEntity entities = _uow.GetRepository<TEntity>().GetByID(id);
                var result = _uow.GetRepository<TEntity>().Remove(entities);
                return new ApiResponse<bool>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Remove");
                return new ApiResponse<bool>(ex.Message);
            }
        }

        public virtual ApiResponse<bool> Update(TRequest entity,int id)
        {
            try
            {
                TEntity entities =  _uow.GetRepository<TEntity>().GetByID(id);
                 var result = _uow.GetRepository<TEntity>().Update(entities);
                return new ApiResponse<bool>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Update");
                return new ApiResponse<bool>(ex.Message);
            }
        }
    }
}
