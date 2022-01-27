using ElasticExample.BusinessLogic.Models;
using ElasticExample.BusinessLogic.Responses;

namespace ElasticExample.BusinessLogic.Queries.Articles
{
    public record GetArticleResponse : BaseResponse<GetArticleResponse>
    {
        public Article? Article { get; init; }
        public User? Author { get; init; }

        public static GetArticleResponse FromSuccess(Article article, User author) => new()
        {
            IsSuccess = true,
            Message = "Ok",
            Article = article,
            Author = author
        };
    }
}