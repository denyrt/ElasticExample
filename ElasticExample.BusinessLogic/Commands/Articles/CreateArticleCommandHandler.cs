using ElasticExample.BusinessLogic.Events.Articles;
using ElasticExample.Data.Contexts;
using ElasticExample.Domain.Constants;
using ElasticExample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ElasticExample.BusinessLogic.Commands.Articles
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleResponse>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;

        public CreateArticleCommandHandler(AppDbContext appDbContext, IMediator mediator)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
        }
        
        public async Task<CreateArticleResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var utcNow = DateTime.UtcNow;
            var entity = new ArticleEntity
            {
                Title = request.Title,
                Content = request.Content,
                CreatedDate = utcNow,
                UpdatedDate = utcNow,
                AuthorId = request.AuthorId
            };

            try
            {
                await _appDbContext.ArticleEntities.AddAsync(entity, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                return new CreateArticleResponse
                {
                    IsSuccess = false,
                    Message = MessageConstants.Conflict
                };
            }

            await _mediator.Publish(new ArticleCreatedEvent(entity.Id), cancellationToken);

            return CreateArticleResponse.FromSuccess(entity.Id);
        }
    }
}