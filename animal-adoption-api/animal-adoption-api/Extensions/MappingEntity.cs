using AutoMapper;
using animal.adoption.api.DTO.HelperModels.Jwt;
using animal.adoption.api.DTO.RequestModels;
using animal.adoption.api.DTO.RequestModels.Auth;
using animal.adoption.api.DTO.ResponseModels.Inner;
using animal.adoption.api.Models;

namespace animal.adoption.api.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            CreateMap<USER, RegisterDto>().ReverseMap();
            CreateMap<POST, PostDto>().ReverseMap();
            CreateMap<PET, PetDto>().ReverseMap();





            CreateMap<POST, PostVM>().ReverseMap();
            CreateMap<PET, PetVM>().ReverseMap();


            CreateMap<USER, JwtCustomClaims>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
