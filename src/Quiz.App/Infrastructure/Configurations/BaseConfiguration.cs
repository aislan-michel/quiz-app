using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Configurations
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.Active);
        }
    }
}