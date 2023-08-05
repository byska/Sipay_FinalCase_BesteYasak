using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.Dtos.User;
using UserModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.User
{
    public interface IUserService: IGenericService<UserModel.User, UserRequest, UserResponse>
    {
    }
}
