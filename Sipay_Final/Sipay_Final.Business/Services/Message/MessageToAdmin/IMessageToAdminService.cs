using Sipay_Final.Business.Services.Generic;
using Sipay_Final.DataAccess.DataAccess.Abstract;
using Sipay_Final.Dtos.MessageAdminToUser;
using Sipay_Final.Dtos.MessageUserToAdmin;
using MessageToAdminModel=Sipay_Final.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.Core.Utilities.Response;

namespace Sipay_Final.Business.Services.Message.MessageToAdmin
{
    public interface IMessageToAdminService : IGenericService<MessageToAdminModel.MessageToAdmin, MessageToAdminRequest, MessageToAdminResponse>
    {
        Task<ApiResponse<bool>> AddMessage(MessageToAdminRequest request, int id);
    }
}
