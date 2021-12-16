using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models;

namespace Quiz.App.Infrastructure.Configurations
{
    public class ScoreConfiguration : BaseConfiguration<Score>
    {
        public override void Configure(EntityTypeBuilder<Score> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Value);
            builder.Property(x => x.TimeToFinish);
            builder.Property(x => x.Passed);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.UserId);
        }
    }
}