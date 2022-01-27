using MediatR;

namespace ElasticExample.BusinessLogic.Commands.Articles
{
    public record CreateArticleCommand : IRequest<CreateArticleResponse>
    {
        public string? Title { get; init; }
        public string? Content { get; init; }
        public Guid AuthorId { get; init; }
    }
}
