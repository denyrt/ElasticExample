using ElasticExample.BusinessLogic.Models;
using ElasticExample.Data.Contexts;
using MediatR;

namespace ElasticExample.BusinessLogic.Queries.Articles
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, GetArticleResponse>
    {
        private readonly AppDbContext _appDbContext;

        public GetArticleQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GetArticleResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { request.Id };
            var entry = await _appDbContext.ArticleEntities.FindAsync(keyValues, cancellationToken);
            
            if (entry == null)
            {
                return new GetArticleResponse
                {
                    IsSuccess = false,
                    Message = "NotFound"
                };
            }

            return GetArticleResponse.FromSuccess(new Article 
            {
                Id = entry.Id,
                Title = entry.Title,
                Content = entry.Content,
                CreatedDate = entry.CreatedDate,
                UpdatedDate = entry.UpdateDate
            });
        }
    }
}