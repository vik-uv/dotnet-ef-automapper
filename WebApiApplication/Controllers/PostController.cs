using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.DTO;
using WebApiApplication.Pipes.Query;

namespace WebApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostController> _logger;

        public PostController(IMediator mediator, ILogger<PostController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "posts")]
        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            return await _mediator.Send(new GetPostsQuery { BlogId = 1 });
        }

        [HttpGet(Name = "titles")]
        public async Task<IEnumerable<PostTitleDto>> GetTitles()
        {
            return await _mediator.Send(new GetPostTitlesQuery { BlogId = 1 });
        }
    }
}