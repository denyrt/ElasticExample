using MediatR;

namespace ElasticExample.BusinessLogic.Commands.Articles
{
    public record CreateArticleCommand : IRequest<CreateArticleResponse>
    {
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
    }
}
