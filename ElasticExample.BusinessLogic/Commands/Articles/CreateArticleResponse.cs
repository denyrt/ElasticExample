using ElasticExample.BusinessLogic.Responses;
using ElasticExample.Domain.Constants;

namespace ElasticExample.BusinessLogic.Commands.Articles
{
    public record CreateArticleResponse : BaseResponse<CreateArticleResponse>
    {
        public Guid Id { get; set; }

        public static CreateArticleResponse FromSuccess(Guid id) => new()
        {
            Id = id,
            IsSuccess = true,
            Message = MessageConstants.Ok
        };
    }
}