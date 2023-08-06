using AutoMapper;
using Sipay_Final.Core.Entities.BaseEntities;
using Sipay_Final.Core.Entities.Interfaces;
using Sipay_Final.Dtos.Admin;
using Sipay_Final.Dtos.Apartment;
using Sipay_Final.Dtos.MessageAdminToUser;
using Sipay_Final.Dtos.MessageUserToAdmin;
using Sipay_Final.Dtos.PayInformation;
using Sipay_Final.Dtos.User;
using Sipay_Final.Entities.DbSets;

namespace Sipay_Final.Business.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();

            CreateMap<Apartment,ApartmentResponse >().ForMember(dest=>dest.UserName,config=>config.MapFrom(src=>src.User.Firstname+" "+src.User.Lastname));
            CreateMap<ApartmentRequest,ApartmentUpdateResponse>();
            CreateMap<ApartmentUpdateResponse,Apartment>().ReverseMap().ForMember(dest => dest.UserName, config => config.MapFrom(src => src.User.Firstname + " " + src.User.Lastname));

            CreateMap<Apartment, ApartmentRequest>().ReverseMap();

            CreateMap<MessageToUser, MessageToUserResponse>().ForMember(dest => dest.AdminName, config => config.MapFrom(src => src.Admin.Firstname + " " + src.Admin.Lastname));
            CreateMap<MessageToUserRequest, MessageToUser>();

            CreateMap<MessageToAdminRequest, MessageToAdmin>();
            CreateMap<MessageToAdmin,MessageToAdminResponse>();

            CreateMap<PayInformation,ApartmentUpdateResponse>().ReverseMap().ForMember(dest=>dest.ApartmentId,config=>config.MapFrom(src=>src.Id));
            CreateMap<PayInformationResponse, PayInformation>().ReverseMap();
            CreateMap<PayInformation, PayInformationCreditResponse>()
                .ForMember(dest => dest.Block, config => config.MapFrom(src => src.Apartment.Block))
                .ForMember(dest => dest.ApartmentNumber, config => config.MapFrom(src => src.Apartment.ApartmentNumber))
                .ForMember(dest => dest.Floor, config => config.MapFrom(src => src.Apartment.Floor));
            
        }
    }
}
