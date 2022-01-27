using ElasticExample.BusinessLogic.Responses;

namespace ElasticExample.BusinessLogic.Commands.Articles
{
    public record CreateArticleResponse : BaseResponse<CreateArticleResponse>
    {
        public Guid Id { get; set; }

        public static CreateArticleResponse FromSuccess(Guid id) => new()
        {
            Id = id,
            IsSuccess = true,
            Message = "Ok"
        };
    }
}