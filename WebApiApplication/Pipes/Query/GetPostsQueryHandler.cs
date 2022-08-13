using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.DB;
using WebApiApplication.DTO;

namespace WebApiApplication.Pipes.Query
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
    {
        private readonly IBloggingContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPostsQueryHandler> _logger;

        public GetPostsQueryHandler(IBloggingContext dbContext, IMapper mapper, ILogger<GetPostsQueryHandler> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Posts.ProjectTo<PostDto>(_mapper.ConfigurationProvider);
            _logger.LogInformation($"SQL query: {query.ToQueryString()}");
            return await query.ToListAsync();
        }
    }
}
