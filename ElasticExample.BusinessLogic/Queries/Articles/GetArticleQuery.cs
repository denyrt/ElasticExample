using MediatR;

namespace ElasticExample.BusinessLogic.Queries.Articles
{
    public record GetArticleQuery : IRequest<GetArticleResponse>
    {
        public Guid Id { get; init; }
    }
}