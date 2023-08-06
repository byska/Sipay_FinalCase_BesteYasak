using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sipay_Final.Business.Services.Apartment;
using Sipay_Final.Business.Services.Message.MessageToUser;
using Sipay_Final.Business.Services.PayInformation;
using Sipay_Final.Business.Services.User;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.DataAccess.Context;
using Sipay_Final.Dtos.MessageAdminToUser;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Dtos.User;
using System.Security.Claims;

namespace Sipay_Final.Api.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPayInformationService _payInformationService;
        private readonly IApartmentService _apartmentService;
        private readonly IMessageToUserService _messageToUserService;
        public UserController(IUserService userService, IPayInformationService payInformationService, IApartmentService apartmentService, IMessageToUserService messageToUserService)
        {
            _userService = userService;
            _payInformationService = payInformationService;
            _apartmentService = apartmentService;
            _messageToUserService= messageToUserService;
        }
       
        [HttpGet]
        public Task<ApiResponse<List<PayInformationResponse>>> GetBillDues()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var id=Convert.ToInt32(userid);
            var apartmentid = _apartmentService.GetAllForUpdate(x=>x.User,x => x.User.Id == id).Result.Response.FirstOrDefault();
          var billDues= _payInformationService.GetAllWithParameters(x=>x.Apartment,x => x.ApartmentId == apartmentid.Id,x=>x.IsActive==true);
            return billDues;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToUserResponse>>> IncomingNewMessage()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
           var newMessages= await _messageToUserService.GetAllWithParameters(x=>x.Admin,x=>x.UserId==Convert.ToInt16(userid),x=>x.Status==Entities.Enums.MessageStatus.New, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToUserResponse>>> IncomingReadMessage()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToUserService.GetAllWithParameters(x => x.Admin,x => x.UserId == Convert.ToInt32(userid), x => x.Status == Entities.Enums.MessageStatus.Read, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToUserResponse>>> IncomingUnreadMessage()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToUserService.GetAllWithParameters(x => x.Admin,x => x.UserId == Convert.ToInt32(userid), x => x.Status == Entities.Enums.MessageStatus.Unread, x => x.IsActive == true);
            return newMessages;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MessageToUserResponse>>> IncomingAllMessage()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var newMessages = await _messageToUserService.GetAllWithParameters(x => x.Admin,x => x.UserId == Convert.ToInt32(userid),x=>x.IsActive==true);
            return newMessages;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> SendMessageToAdmin([FromBody]MessageToUserRequest request)
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
           var response=await _messageToUserService.AddMessage(request, Convert.ToInt16(userid));
            return response;
        }
    }
}
