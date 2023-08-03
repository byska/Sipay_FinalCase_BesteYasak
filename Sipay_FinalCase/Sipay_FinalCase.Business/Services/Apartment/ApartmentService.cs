using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Dtos.Apartment;
using ApartmentModel=Sipay_FinalCase.Entities.DbSets;
using Sipay_FinalCase.Core.UnitOfWork;
using AutoMapper;
using Sipay_FinalCase.Core.Utilities.Response;
using System.Linq.Expressions;
using Serilog;

namespace Sipay_FinalCase.Business.Services.Apartment
{
    public class ApartmentService : GenericService<ApartmentModel.Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public ApartmentService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IQueryable<ApartmentUpdateResponse>>> GetAllForUpdate(Expression<Func<ApartmentModel.Apartment, bool>> exp, params Expression<Func<ApartmentModel.Apartment, object>>[] includes)
        {
            try
            {
                var result = await _uow.GetRepository<ApartmentModel.Apartment>().GetAllAsync(exp, includes);
                var response = _mapper.Map<IQueryable<ApartmentUpdateResponse>>(result);
                return new ApiResponse<IQueryable<ApartmentUpdateResponse>>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.GetAllForUpdate");
                return new ApiResponse<IQueryable<ApartmentUpdateResponse>>(ex.Message);
            }
        }
    }
}
