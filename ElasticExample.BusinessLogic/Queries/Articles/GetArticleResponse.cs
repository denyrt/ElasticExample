using ElasticExample.BusinessLogic.Models;
using ElasticExample.BusinessLogic.Responses;

namespace ElasticExample.BusinessLogic.Queries.Articles
{
    public record GetArticleResponse : BaseResponse<GetArticleResponse>
    {
        public Article? Article { get; init; }

        public static GetArticleResponse FromSuccess(Article article) => new()
        {
            IsSuccess = true,
            Message = "Ok",
            Article = article
        };
    }
}