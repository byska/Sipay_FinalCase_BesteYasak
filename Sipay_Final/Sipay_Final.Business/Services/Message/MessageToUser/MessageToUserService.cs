using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Dtos.MessageAdminToUser;
using System;
using MessageToUserModel = Sipay_Final.Entities.DbSets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Final.DataAccess.UnitOfWork;
using AutoMapper;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Entities.DbSets;
using Serilog;

namespace Sipay_Final.Business.Services.Message.MessageToUser
{
    public class MessageToUserService : GenericService<MessageToUserModel.MessageToUser, MessageToUserRequest, MessageToUserResponse>, IMessageToUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public MessageToUserService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ApiResponse<bool>> AddMessage(MessageToUserRequest request,int id)
        {
            try
            {
                var user= _uow.GetRepository< MessageToUserModel.User>().GetByID(id);
               var admin= _uow.GetRepository<MessageToUserModel.Admin>().GetByID(request.AdminId);
                if(admin == null)
                {
                    return new ApiResponse<bool>(false);
                }
                var message = _mapper.Map<MessageToUserRequest, MessageToUserModel.MessageToUser>(request);
                message.UserId = id;
                message.AdminId = request.AdminId;
                message.CreatedBy = user.Firstname + " " + user.Lastname;
                var response = await _uow.GetRepository<MessageToUserModel.MessageToUser>().Add(message);
                _uow.Complete();
                return new ApiResponse<bool>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MessageToUserService.AddMessage");
                return new ApiResponse<bool>(false);
            }
         
        }
    }
}
