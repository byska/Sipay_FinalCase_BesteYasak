using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Core.Utilities.Response;
using Sipay_FinalCase.Dtos.Apartment;
using Sipay_FinalCase.Dtos.User;
using System.Linq.Expressions;
using UserModel=Sipay_FinalCase.Entities.DbSets;

namespace Sipay_FinalCase.Business.Services.User
{
    public interface IUserService: IGenericService<UserModel.User, UserRequest, UserResponse>
    {
        
    }
}
