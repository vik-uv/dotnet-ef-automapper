using MediatR;
using WebApiApplication.DB.Models;
using WebApiApplication.DTO;

namespace WebApiApplication.Pipes.Query
{
    public class GetPostsQuery : IRequest<IEnumerable<PostDto>>
    {
        public int BlogId { get; set; }
    }
}
