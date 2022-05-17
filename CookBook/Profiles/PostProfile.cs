using AutoMapper;
using CookBook.Domain.Models;
using CookBook.Dtos.PostDtos;

namespace CookBook.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            //Mapping post GET
            CreateMap<PostGetDto, Post>()
                .ForMember(d => d.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(d => d.UserId, opt => opt.MapFrom(p => p.UserId))
                .ForMember(d => d.User, opt => opt.MapFrom(p => p.User))
                .ForMember(d => d.Title, opt => opt.MapFrom(p => p.Title))
                .ForMember(d => d.Content, opt => opt.MapFrom(p => p.Content))
                .ForMember(d => d.LikeCounter, opt => opt.MapFrom(p => p.LikeCounter))
                .ForMember(d => d.DislikeCunter, opt => opt.MapFrom(p => p.DislikeCunter))
                .ForMember(d => d.Category, opt => opt.MapFrom(p => p.Category))
                .ReverseMap();

            //Mapping post PUT POST PATCH
            CreateMap<PostPutPostDto, Post>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(p => p.UserId))
                .ForMember(d => d.Title, opt => opt.MapFrom(p => p.Title))
                .ForMember(d => d.Content, opt => opt.MapFrom(p => p.Content))
                .ForMember(d => d.LikeCounter, opt => opt.MapFrom(p => p.LikeCounter))
                .ForMember(d => d.DislikeCunter, opt => opt.MapFrom(p => p.DislikeCunter))
                .ForMember(d => d.Category, opt => opt.MapFrom(p => p.Category))
                .ReverseMap();
        }
    }
}
