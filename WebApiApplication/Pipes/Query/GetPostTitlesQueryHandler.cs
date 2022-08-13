using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.DB;
using WebApiApplication.DTO;

namespace WebApiApplication.Pipes.Query
{
    public class GetPostTitlesQueryHandler : IRequestHandler<GetPostTitlesQuery, IEnumerable<PostTitleDto>>
    {
        private readonly IBloggingContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPostTitlesQueryHandler> _logger;

        public GetPostTitlesQueryHandler(IBloggingContext dbContext, IMapper mapper, ILogger<GetPostTitlesQueryHandler> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PostTitleDto>> Handle(GetPostTitlesQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Posts.ProjectTo<PostTitleDto>(_mapper.ConfigurationProvider);
            _logger.LogInformation($"SQL query: {query.ToQueryString()}");
            return await query.ToListAsync();
        }
    }
}
