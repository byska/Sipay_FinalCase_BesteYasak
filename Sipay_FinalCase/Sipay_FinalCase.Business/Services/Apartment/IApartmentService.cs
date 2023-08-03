using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Core.Utilities.Response;
using Sipay_FinalCase.Dtos.Apartment;
using System.Linq.Expressions;
using ApartmentModel=Sipay_FinalCase.Entities.DbSets;

namespace Sipay_FinalCase.Business.Services.Apartment
{
    public interface IApartmentService:IGenericService<ApartmentModel.Apartment,ApartmentRequest,ApartmentResponse>
    {
        Task<ApiResponse<IQueryable<ApartmentUpdateResponse>>> GetAllForUpdate(Expression<Func<ApartmentModel.Apartment, bool>> exp, params Expression<Func<ApartmentModel.Apartment, object>>[] includes);
    }
}
