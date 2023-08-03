using Sipay_FinalCase.Business.Services.Apartment;
using Sipay_FinalCase.Business.Services.Generic;
using Sipay_FinalCase.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_FinalCase.Dtos.User;
using UserModel = Sipay_FinalCase.Entities.DbSets;
using AutoMapper;
using Sipay_FinalCase.Core.UnitOfWork;
using Sipay_FinalCase.Core.Utilities.Response;
using System.Linq.Expressions;
using Serilog;
using Sipay_FinalCase.Dtos.Apartment;

namespace Sipay_FinalCase.Business.Services.User
{
    public class UserService : GenericService<UserModel.User, UserRequest, UserResponse>,IUserService
    {
       
        public UserService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            
        }

       
    }
}
