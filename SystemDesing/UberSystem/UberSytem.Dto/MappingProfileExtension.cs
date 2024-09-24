using AutoMapper;
using UberSystem.Domain.Entities;
using UberSytem.Dto.Requests;
using UberSytem.Dto.Responses;

namespace UberSytem.Dto
{
    public class MappingProfileExtension : Profile
    {
        /// <summary>
        /// Mapping
        /// </summary>
        public MappingProfileExtension()
        {
            CreateMap<User, Customer>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Helper.GenerateRandomLong()));
            CreateMap<User, Driver>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Helper.GenerateRandomLong()));

            CreateMap<User, UserResponseModel>();
            CreateMap<SignupModel, User>()
                // Default value: False
                .ForMember(dest => dest.EmailVerified, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.EmailVerificationToken, opt => opt.MapFrom(src => src.EmailVerifiedToken));
        }
    }
}
