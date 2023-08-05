using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.Apartment;
using System.Linq.Expressions;
using ApartmentModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.Apartment
{
    public interface IApartmentService:IGenericService<ApartmentModel.Apartment,ApartmentRequest,ApartmentResponse>
    {
        Task<ApiResponse<List<ApartmentUpdateResponse>>> GetAllForUpdate(Expression<Func<ApartmentModel.Apartment, object>> include, params Expression<Func<ApartmentModel.Apartment, bool>>[] exps );
        Task<ApiResponse<bool>> SendBillDues(int totalGasBill, int totalElectricityBill, int totalWaterBill, int totalDues);

    }
}
