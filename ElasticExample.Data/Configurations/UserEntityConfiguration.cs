using ElasticExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElasticExample.Data.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.ArticleEntities).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);

            builder.HasData(new UserEntity[]
            {
                new()
                {
                    Id = Guid.Parse("55759079-471B-4C52-AFC2-075F64D46BE3"),
                    Username = "Hash"
                },
                new()
                {
                    Id = Guid.Parse("0487AFC2-E528-48C3-BCA2-1DA5ADF72BAF"),
                    Username = "Denis"
                }
            });
        }
    }
}