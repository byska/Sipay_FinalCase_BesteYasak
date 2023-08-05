using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sipay_Final.Core.Entities.BaseEntities;
using Sipay_Final.Core.Entities.Enums;
using Sipay_Final.Core.JWT;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.DataAccess.UnitOfWork;
using Sipay_Final.Dtos.Token;
using Sipay_Final.Entities.DbSets;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IUow _uow;
        private readonly JwtConfig _jwtConfig;
        public TokenService(IUow uow, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _uow = uow;
            _jwtConfig = jwtConfig.CurrentValue;
        }

        public async Task<ApiResponse<TokenResponse>> Login(TokenRequest request)
        {
            if (request is null)
            {
                return new ApiResponse<TokenResponse>("Request was null");
            }
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return new ApiResponse<TokenResponse>("Request was null");
            }

            request.Email = request.Email.Trim().ToLower();
            request.Password = request.Password.Trim();

            BaseUser user;
            user = await _uow.GetRepository<UserModel.User>().GetByDefault(x => x.Email.Equals(request.Email));
            if (user == null)
            {
                user = await _uow.GetRepository<Admin>().GetByDefault(x => x.Email.Equals(request.Email));
            }
            
            if (user is null)
            {
                return new ApiResponse<TokenResponse>("Invalid user informations");
            }

            if (user.Password.ToLower() != request.Password.ToLower())
            {
                user.LastActivity = DateTime.UtcNow;
                if (user is UserModel.User)
                {
                    _uow.GetRepository<UserModel.User>().Update((UserModel.User)user);
                }
               else
                {
                    _uow.GetRepository<Admin>().Update((Admin)user);
                }
                _uow.Complete();

                return new ApiResponse<TokenResponse>("Invalid user informations");
            }

            string token = Token(user);

            TokenResponse response = new()
            {
                AccessToken = token,
                ExpireTime = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                Email = user.Email
            };

            return new ApiResponse<TokenResponse>(response);
        }
        private string Token(BaseUser user)
        {
            Claim[] claims = GetClaims(user);
            var secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
               issuer: _jwtConfig.Issuer,
               audience: _jwtConfig.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }


        private Claim[] GetClaims(BaseUser user)
        {
            if (user is Admin)
            {
                user.Role = Role.admin;
            }
            else
            {
                user.Role = Role.user;
            }
            var claims = new[]
            {
            new Claim("Email",user.Email),
            new Claim("Id",user.Id.ToString()),
            new Claim("Role",user.Role.ToString()),
            new Claim(ClaimTypes.Role,user.Role.ToString())
        };

            return claims;
        }


        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes).ToLower();

            }
        }
    }
}
