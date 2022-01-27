namespace ElasticExample.Elasticsearch.Indices
{
    public record ArticleIndex
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Content { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
        public Guid AuthorId { get; init; }
        public string? AuthorName { get; init; }
    }
}
