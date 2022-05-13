using AutoMapper;
using CookBook.Domain.Models;
using CookBook.Dtos.AdminDtos;

namespace CookBook.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            //Mapping for admin GET
            CreateMap<AdminGetDto, Admin>()
                .ForMember(d => d.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(d => d.AdminId, opt => opt.MapFrom(a => a.AdminId))
                .ForMember(d => d.UserName, opt => opt.MapFrom(a => a.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(a => a.Password))
                .ReverseMap();

            //Mapping for admin PUT POST PUSH
            CreateMap<AdminPutPostDto, Admin>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(a => a.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(a => a.Password))
                .ReverseMap();
        }
    }
}
