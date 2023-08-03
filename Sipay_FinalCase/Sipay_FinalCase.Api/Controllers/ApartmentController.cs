using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_FinalCase.Business.Services.Apartment;
using Sipay_FinalCase.Business.Services.User;
using Sipay_FinalCase.Core.Utilities.Response;
using Sipay_FinalCase.Dtos.Apartment;
using Sipay_FinalCase.Dtos.User;
using Sipay_FinalCase.Entities.DbSets;

namespace Sipay_FinalCase.Api.Controllers
{
    [Route("api/[controller]")]
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
            var response = await _service.GetAll();
            return response;
        }
        [HttpGet]
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
        [HttpPost]
        public async Task<ApiResponse<IQueryable<ApartmentUpdateResponse>>> SendBillDues(int totalGasBill, int totalElectricityBill, int totalWaterBill, int totalDues)
        {
            //var users = await _userService.GetAll(x => x.IsActive);
            //var userCount = users.Response.Count();

            var apartments = await _service.GetAllForUpdate(x => x.IsActive == true, x => x.User != null,x=>x.PayInformation);
            var apartmentCount=apartments.Response.Count();
            
            //var apartmentList = _mapper.Map<IQueryable<Apartment>>(apartments);
            foreach (var apartment in apartments.Response)
            {
                apartment.GasBill = totalGasBill / apartmentCount;
                apartment.GasBillDate = DateTime.Now;
                apartment.ElectricityBill = totalElectricityBill / apartmentCount;
                apartment.ElectricityBillDate= DateTime.Now;
                apartment.WaterBill = totalWaterBill / apartmentCount;
                apartment.WaterBillDate= DateTime.Now;
                apartment.Dues = totalDues/apartmentCount;
                apartment.DuesDate= DateTime.Now;
                
                var apartmentRequest = _mapper.Map<ApartmentRequest>(apartment);
                _service.Update(apartmentRequest,apartment.Id);
            }
            return apartments;



        }
    }
}
