using AutoMapper;
using Serilog;
using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Core.UnitOfWork;
using Sipay_FinalCase.Core.Utilities.Response;
using Sipay_FinalCase.Dtos.MessageAdminToUser;
using Sipay_FinalCase.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Business.Services.Message
{
    public class MessageAdminToUserService:GenericService<MessageAdminToUser,MessageAdminToUserRequest,MessageAdminToUserResponse>, IMessageAdminToUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public MessageAdminToUserService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow= uow;
            _mapper= mapper;
        }
        //public override async Task<ApiResponse<bool>> Add(MessageAdminToUserRequest request)
        //{
        //    try
        //    {
        //        var message = _mapper.Map<MessageAdminToUser>(request);
        //        //giriş yapan kullanıcının bilgilerini getir.
        //        message.AdminId=
        //    }
        //    catch (Exception ex)
        //    {

        //        Log.Error(ex, "GenericService.MessageToUserAdd");
        //        return new ApiResponse<bool>(false);
        //    }
        //}
        
    }
}
