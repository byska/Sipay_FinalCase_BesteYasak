using Sipay_Final.Business.Services.Generic;
using System;
using PayInformationModel = Sipay_Final.Entities.DbSets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.DataAccess.UnitOfWork;
using AutoMapper;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.PayInformation
{
    public class PayInformationService : GenericService<PayInformationModel.PayInformation, PayInformationRequest, PayInformationResponse>, IPayInformationService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public PayInformationService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ApiResponse<List<PayInformationCreditResponse>>> GetCredit()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var credit =await _uow.GetRepository<PayInformationModel.PayInformation>().GetAllByParametersAsync(x=>x.Apartment,x => x.BillDuesDate.Value.Month == currentMonth && x.BillDuesDate.Value.Year == currentYear,x=>x.IsActive==true);

           var creditResponse = _mapper.Map<List<PayInformationCreditResponse>>(credit.ToList());
            return new ApiResponse<List<PayInformationCreditResponse>>(creditResponse);
        }
           

    }

}
