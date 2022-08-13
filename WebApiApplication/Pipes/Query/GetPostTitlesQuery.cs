using MediatR;
using WebApiApplication.DB.Models;
using WebApiApplication.DTO;

namespace WebApiApplication.Pipes.Query
{
    public class GetPostTitlesQuery : IRequest<IEnumerable<PostTitleDto>>
    {
        public int BlogId { get; set; }
    }
}
