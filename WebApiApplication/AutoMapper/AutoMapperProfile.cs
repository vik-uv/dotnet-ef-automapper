using AutoMapper;
using WebApiApplication.DB.Models;
using WebApiApplication.DTO;

namespace WebApiApplication.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(d => d.BlogUrl, x => x.MapFrom(s => s.Blog.Url))
                .ForMember(d => d.TagValues, x => x.MapFrom(s => s.Tags.Select(xx => xx.Title)));

            CreateMap<Post, PostTitleDto>();
        }
    }
}
