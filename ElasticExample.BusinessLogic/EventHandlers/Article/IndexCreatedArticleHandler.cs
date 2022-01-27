using ElasticExample.BusinessLogic.Events.Articles;
using ElasticExample.Data.Contexts;
using ElasticExample.Elasticsearch.Indices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace ElasticExample.BusinessLogic.EventHandlers.Article
{
    internal class IndexCreatedArticleHandler : INotificationHandler<ArticleCreatedEvent>
    {
        private readonly IElasticClient _elasticsearchClient;
        private readonly AppDbContext _appDbContext;

        public IndexCreatedArticleHandler(IElasticClient elasticsearchClient, AppDbContext appDbContext)
        {
            _elasticsearchClient = elasticsearchClient;
            _appDbContext = appDbContext;
        }

        public async Task Handle(ArticleCreatedEvent notification, CancellationToken cancellationToken)
        {
            var articleEntity = await _appDbContext.ArticleEntities
                .Include(x => x.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == notification.ArticleId, cancellationToken);

            if (articleEntity == null) return;

            var mappedIndex = new ArticleIndex
            {
                Id = articleEntity.Id,
                Title = articleEntity.Title,
                Content = articleEntity.Content,
                CreatedDate = articleEntity.CreatedDate,
                UpdatedDate = articleEntity.UpdatedDate,
                AuthorId = articleEntity.AuthorId,
                AuthorName = articleEntity.Author?.Username
            };

            await _elasticsearchClient.IndexAsync(mappedIndex, x => x.Index("articles"), cancellationToken);
        }
    }
}
