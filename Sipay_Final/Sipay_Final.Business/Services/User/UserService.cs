using AutoMapper;
using Serilog;
using Sipay_Final.Business.Services.Generic;
using Sipay_Final.Core.Entities.Interfaces;
using Sipay_Final.Core.Utilities.Response;
using Sipay_Final.DataAccess.UnitOfWork;
using Sipay_Final.Dtos.User;
using Sipay_Final.Entities.DbSets;
using UserModel = Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Services.User
{
    public class UserService : GenericService<UserModel.User, UserRequest, UserResponse>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public UserService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _mapper= mapper;
            _uow= uow;
        }
        public override ApiResponse<bool> Update(UserRequest entity, int id)
        {
                var user = _uow.GetRepository<UserModel.User>().GetByID(id);
                if (user == null)
                {
                    return new ApiResponse<bool>("Record not found!");
                }

                user.Firstname=string.IsNullOrEmpty(entity.FirstName) ? user.Firstname : entity.FirstName;
                user.Lastname=string.IsNullOrEmpty(entity.LastName) ? user.Lastname : entity.LastName;
                user.Email=string.IsNullOrEmpty(entity.Email) ? user.Email : entity.Email;
                user.Tc=string.IsNullOrEmpty(entity.Tc) ? user.Tc : entity.Tc;
                user.Phone=string.IsNullOrEmpty(entity.Phone) ? user.Phone : entity.Phone;
                user.LicensePlate=string.IsNullOrEmpty(entity.LicensePlate) ? user.LicensePlate : entity.LicensePlate;
                user.ApartmentId=entity.ApartmentId==0 ? user.ApartmentId : entity.ApartmentId;

                var result = _uow.GetRepository<UserModel.User>().Update(user);
                _uow.Complete();
                return new ApiResponse<bool>(result);
        }
        
    }
}
