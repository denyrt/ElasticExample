using ElasticExample.BusinessLogic.Models;
using ElasticExample.Domain.Constants;
using ElasticExample.Elasticsearch.Indices;
using MediatR;
using Nest;

namespace ElasticExample.BusinessLogic.Queries.Articles
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, GetArticleResponse>
    {
        private readonly IElasticClient _elasticsearchClient;

        public GetArticleQueryHandler(IElasticClient elasticsearchClient)
        {
            _elasticsearchClient = elasticsearchClient;
        }

        public async Task<GetArticleResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var entry = await _elasticsearchClient.GetAsync(
                DocumentPath<ArticleIndex>.Id(request.Id), 
                x => x.Index("articles"),
                cancellationToken);
            
            if (!entry.Found)
            {
                return new GetArticleResponse
                {
                    IsSuccess = false,
                    Message = MessageConstants.NotFound
                };
            }

            var article = new Article
            {
                Id = entry.Source.Id,
                Title = entry.Source.Title,
                Content = entry.Source.Content,
                CreatedDate = entry.Source.CreatedDate,
                UpdatedDate = entry.Source.UpdatedDate
            };

            var author = new User
            {
                Id = entry.Source.AuthorId,
                Username = entry.Source.AuthorName
            };

            return GetArticleResponse.FromSuccess(article, author);
        }
    }
}