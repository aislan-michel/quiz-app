using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models;

namespace Quiz.App.Infrastructure.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name);

            builder.HasMany(x => x.Questions).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            
            base.Configure(builder);
        }
    }
}