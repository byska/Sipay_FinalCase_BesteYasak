using AutoMapper;
using Serilog;
using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.DataAccess.UnitOfWork;
using Sipay_Final.Dtos.MessageUserToAdmin;
using MessageToAdminModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.Message.MessageToAdmin
{
    public class MessageToAdminService : GenericService<MessageToAdminModel.MessageToAdmin, MessageToAdminRequest, MessageToAdminResponse>,IMessageToAdminService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public MessageToAdminService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ApiResponse<bool>> AddMessage(MessageToAdminRequest request, int id)
        {
            try
            {
                var admin = _uow.GetRepository<MessageToAdminModel.Admin>().GetByID(id);
                var user = _uow.GetRepository<MessageToAdminModel.User>().GetByID(request.UserId);
                if (user == null)
                {
                    return new ApiResponse<bool>(false);
                }
                var message = _mapper.Map<MessageToAdminRequest, MessageToAdminModel.MessageToAdmin>(request);
                message.AdminId = id;
                message.UserId = request.UserId;
                message.CreatedBy = admin.Firstname + " " + admin.Lastname;
                var response = await _uow.GetRepository<MessageToAdminModel.MessageToAdmin>().Add(message);
                _uow.Complete();
                return new ApiResponse<bool>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MessageToAdminService.AddMessage");
                return new ApiResponse<bool>(false);
            }

        }
    }
}
