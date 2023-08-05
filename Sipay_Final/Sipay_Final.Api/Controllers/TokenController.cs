using Microsoft.AspNetCore.Mvc;
using Sipay_Final.Business.Services.Token;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.Token;

namespace Sipay_Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService service;
        public TokenController(ITokenService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        public async Task<ApiResponse<TokenResponse>> Post([FromBody] TokenRequest request)
        {
            var response =await service.Login(request);
            return response;
        }
    }
}
