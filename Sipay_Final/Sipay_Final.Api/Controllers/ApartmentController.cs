using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sipay_Final.Business.Services.Apartment;
using Sipay_Final.Business.Services.User;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.Apartment;
using Sipay_Final.Entities.DbSets;
using Sipay_Final.Entities.Enums;

namespace Sipay_Final.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ApartmentController(IApartmentService service, IUserService userService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody] ApartmentRequest request)
        {
            var response = await _service.Add(request);
            return response;
        }
        [HttpGet]
        public async Task<ApiResponse<List<ApartmentResponse>>> GetAll()
        {
            var response = await _service.GetAllWithParameters(x=>x.User,x=>x.IsActive==true);
            return response;
        }
        [HttpGet("{id}")]
        public ApiResponse<ApartmentResponse> GetById(int id)
        {
            var response = _service.GetById(id);
            return response;
        }
        [HttpPut("{id}")]
        public ApiResponse<bool> Put([FromBody] ApartmentRequest request, int id)
        {
            var response = _service.Update(request, id);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var response = _service.Remove(id);
            return response;
        }
        [HttpPost("{totalGasBill}/{totalElectricityBill}/{totalWaterBill}/{totalDues}")]
        public async Task<ApiResponse<bool>> SendBillDues(int totalGasBill, int totalElectricityBill, int totalWaterBill, int totalDues)
        {
           var response=await _service.SendBillDues(totalGasBill, totalElectricityBill, totalWaterBill, totalDues);
            return response;
        }
    }
}
