using Sipay_Final.Business.Services.Generic;
using PayInformationModel = Sipay_Final.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Core.Utilities.Response;

namespace Sipay_Final.Business.Services.PayInformation
{
    public interface IPayInformationService : IGenericService<PayInformationModel.PayInformation,PayInformationRequest,PayInformationResponse>
    {
        Task<ApiResponse<List<PayInformationCreditResponse>>> GetCredit();
    }
}
