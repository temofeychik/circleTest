using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserReply, Domain.User>()
                .ForMember(dest =>
                    dest.City,
                    opt => opt.MapFrom(src => src.City))
                .ForMember(dest =>
                    dest.DateOfBith,
                    opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest =>
                    dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();

            CreateMap<UserRequest, Domain.User>()
                .ForMember(dest =>
                    dest.City,
                    opt => opt.MapFrom(src => src.City))
                .ForMember(dest =>
                    dest.DateOfBith,
                    opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest =>
                    dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
        }
    }
}
