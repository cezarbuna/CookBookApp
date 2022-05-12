using AutoMapper;
using CookBook.Domain.Models;
using CookBook.Dtos.UserDtos;

namespace CookBook.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Mapping user GET
            CreateMap<UserGetDto, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(d => d.UserName, opt => opt.MapFrom(u => u.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(u => u.PhoneNumber))
                .ForMember(d => d.CurrentOccupation, opt => opt.MapFrom(u => u.CurrentOccupation))
                .ForMember(d => d.Description, opt => opt.MapFrom(u => u.Description))
                .ReverseMap();

            //Mapping user PUT POST PATCH
            CreateMap<UserPutPostDto, User>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(u => u.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(u => u.PhoneNumber))
                .ForMember(d => d.CurrentOccupation, opt => opt.MapFrom(u => u.CurrentOccupation))
                .ForMember(d => d.Description, opt => opt.MapFrom(u => u.Description))
                .ReverseMap();

        }
    }
}
