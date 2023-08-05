using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Dtos.MessageAdminToUser;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Entities.DbSets;
using MessageToUserModel = Sipay_Final.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.Core.Utilities.Response;

namespace Sipay_Final.Business.Services.Message.MessageToUser
{
    public interface IMessageToUserService : IGenericService<MessageToUserModel.MessageToUser, MessageToUserRequest, MessageToUserResponse>
    {
        Task<ApiResponse<bool>> AddMessage(MessageToUserRequest request, int id);
    }
}
