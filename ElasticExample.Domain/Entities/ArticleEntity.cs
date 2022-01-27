namespace ElasticExample.Domain.Entities
{
    public class ArticleEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
