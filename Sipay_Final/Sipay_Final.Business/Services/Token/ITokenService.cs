using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Business.Services.Token
{
    public interface ITokenService
    {
        Task<ApiResponse<TokenResponse>> Login(TokenRequest request);
    }
}
