using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_FinalCase.Business.Services.Apartment;
using Sipay_FinalCase.Business.Services.User;
using Sipay_FinalCase.Core.Utilities.Response;
using Sipay_FinalCase.Dtos.Apartment;
using Sipay_FinalCase.Dtos.User;

namespace Sipay_FinalCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        public AdminController(IUserService userService, IApartmentService apartmentService,IMapper mapper)
        {
            _userService = userService;
            _apartmentService = apartmentService;
            _mapper = mapper;
        }
        [HttpPost("{id}")]
        public async Task<ApiResponse<bool>> CreateUser([FromBody] UserRequest request, int apartmentid)
        {

            var response = await _userService.Add(request);
            return response;

        }
        //[HttpGet]
        //public ApiResponse GetMessage()
        //{

        //}
    }
}
