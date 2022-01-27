namespace ElasticExample.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public IList<ArticleEntity>? ArticleEntities { get; set; }
    }
}