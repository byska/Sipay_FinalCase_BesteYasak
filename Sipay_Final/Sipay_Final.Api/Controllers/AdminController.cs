using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sipay_Final.Business.Services.Apartment;
using Sipay_Final.Business.Services.Message.MessageToAdmin;
using Sipay_Final.Business.Services.PayInformation;
using Sipay_Final.Business.Services.User;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.MessageUserToAdmin;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Dtos.User;
using System.Security.Claims;

namespace Sipay_Final.Api.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        private readonly IMessageToAdminService _messageToAdminService;
        private readonly IPayInformationService _payInformationService;
        public AdminController(IUserService userService, IApartmentService apartmentService,IMapper mapper, IMessageToAdminService messageToAdminService,IPayInformationService payInformationService)
        {
            _userService = userService;
            _apartmentService = apartmentService;
            _mapper = mapper;
            _messageToAdminService= messageToAdminService;
            _payInformationService= payInformationService;
        }

        [HttpPost]
        public async Task<ApiResponse<bool>> CreateUser([FromBody] UserRequest request)
        {

            var response = await _userService.Add(request);
            return response;

        }
        [HttpGet]
        public async Task<ApiResponse<List<UserResponse>>> UserList()
        {
            var users =await _userService.GetActive();
            return users;

        }
        [HttpPut("{id}")]
        public ApiResponse<bool> UserUpdate(int id, [FromBody] UserRequest request)
        {
            var response=_userService.Update(request,id);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> UserDelete(int id)
        {
            var response=_userService.Remove(id);
            return response;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToAdminResponse>>> IncomingNewMessage()
        {
            var adminid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToAdminService.GetAllWithParameters(x => x.User, x => x.AdminId == Convert.ToInt16(adminid), x => x.Status == Entities.Enums.MessageStatus.New, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToAdminResponse>>> IncomingReadMessage()
        {
            var adminid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToAdminService.GetAllWithParameters(x => x.User, x => x.AdminId == Convert.ToInt32(adminid), x => x.Status == Entities.Enums.MessageStatus.Read, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToAdminResponse>>> IncomingUnreadMessage()
        {
            var adminid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToAdminService.GetAllWithParameters(x => x.User, x => x.AdminId == Convert.ToInt32(adminid), x => x.Status == Entities.Enums.MessageStatus.Unread, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToAdminResponse>>> IncomingAllMessage()
        {
            var adminid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToAdminService.GetAllWithParameters(x => x.User, x => x.AdminId == Convert.ToInt32(adminid), x => x.IsActive == true);
            return newMessages;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> SendMessageToAdmin([FromBody] MessageToAdminRequest request)
        {
            var adminid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var response = await _messageToAdminService.AddMessage(request, Convert.ToInt16(adminid));
            return response;
        }
        [HttpGet]
        public async Task<ApiResponse<List<PayInformationCreditResponse>>> CreditList()
        {
           var response=await _payInformationService.GetCredit();
            return response;
        }
    }
}
