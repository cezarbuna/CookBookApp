using AutoMapper;
using CookBook.Domain.Models;
using CookBook.Dtos.CommentDtos;

namespace CookBook.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            //Mapping comment GET
            CreateMap<CommentGetDto, Comment>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.PostId, opt => opt.MapFrom(c => c.PostId))
                .ForMember(d => d.Post, opt => opt.MapFrom(c => c.Post))
                .ForMember(d => d.Content, opt => opt.MapFrom(c => c.Content))
                .ReverseMap();

            //Mapping comment PUT POST PATCH
            CreateMap<CommentPutPostDto, Comment>()
                .ForMember(d => d.PostId, opt => opt.MapFrom(c => c.PostId))
                .ForMember(d => d.Content, opt => opt.MapFrom(c => c.Content))
                .ReverseMap();
        }
    }
}
