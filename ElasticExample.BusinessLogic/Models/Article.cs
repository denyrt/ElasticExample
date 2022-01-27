namespace ElasticExample.BusinessLogic.Models
{
    public record Article
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Content { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
    }
}