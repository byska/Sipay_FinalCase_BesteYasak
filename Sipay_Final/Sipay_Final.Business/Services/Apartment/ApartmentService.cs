using AutoMapper;
using Serilog;
using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.DataAccess.UnitOfWork;
using Sipay_Final.Dtos.Apartment;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Entities.DbSets;
using System.Linq.Expressions;
using ApartmentModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.Apartment
{
    public class ApartmentService : GenericService<ApartmentModel.Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public ApartmentService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ApiResponse<List<ApartmentUpdateResponse>>> GetAllForUpdate(Expression<Func<ApartmentModel.Apartment, object>> include, params Expression<Func<ApartmentModel.Apartment, bool>>[] exps)
        {
            var result = await _uow.GetRepository<ApartmentModel.Apartment>().GetAllByParametersAsync(include, exps);
            var response = _mapper.Map<List<ApartmentModel.Apartment>, List<ApartmentUpdateResponse>>(result.ToList());
            return new ApiResponse<List<ApartmentUpdateResponse>>(response);
        }

        public async Task<ApiResponse<bool>> SendBillDues(int totalGasBill, int totalElectricityBill, int totalWaterBill, int totalDues)
        {
            var apartments = await GetAllForUpdate(x => x.PayInformations, x => x.User != null, x => x.IsActive == true, x => x.Status == Entities.Enums.ApartmentStatus.Full);
            var apartmentCount = apartments.Response.Count();
            if (apartments.Response.Count() == 0)
            {
                return new ApiResponse<bool>(false);
            }

            foreach (var apartment in apartments.Response)
            {
                apartment.GasBill = totalGasBill / apartmentCount;
                apartment.ElectricityBill = totalElectricityBill / apartmentCount;
                apartment.WaterBill = totalWaterBill / apartmentCount;
                apartment.Dues = totalDues / apartmentCount;
                apartment.BillDuesDate = DateTime.Now;

                var payInformation = _mapper.Map<ApartmentModel.PayInformation>(apartment);
                payInformation.CreatedBy = "admin";
                payInformation.Id = 0;
                var response =await _uow.GetRepository<ApartmentModel.PayInformation>().Add(payInformation);
                _uow.Complete();

                
            }
            return new ApiResponse<bool>(true);

        }

    }
}
