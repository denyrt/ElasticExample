namespace ElasticExample.Elasticsearch.Indices
{
    public record ArticleIndex
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public DateTime CreateDate { get; init; }
        public DateTime UpdateDate { get; init; }
    }
}
