using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Dtos.MessageAdminToUser;
using Sipay_FinalCase.Dtos.MessageUserToAdmin;
using Sipay_FinalCase.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Business.Services.Message
{
    public interface IMessageAdminToUserService:IGenericService<MessageAdminToUser,MessageAdminToUserRequest,MessageAdminToUserResponse>
    {
    }
}
