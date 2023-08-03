using AutoMapper;
using Sipay_FinalCase.Dtos.Apartment;
using Sipay_FinalCase.Dtos.User;
using Sipay_FinalCase.Entities.DbSets;

namespace Sipay_FinalCase.Business.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserResponse, User>();

            CreateMap<ApartmentResponse, Apartment>().ReverseMap();
            CreateMap<ApartmentUpdateResponse, ApartmentRequest>();
            CreateMap<Apartment, ApartmentUpdateResponse>();
            CreateMap<ApartmentRequest, Apartment>();

        }
    }
}
