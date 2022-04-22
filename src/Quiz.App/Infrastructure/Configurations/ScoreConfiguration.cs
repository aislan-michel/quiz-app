using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Configurations
{
    public class ScoreConfiguration : BaseConfiguration<Score>
    {
        public override void Configure(EntityTypeBuilder<Score> builder)
        {
            base.Configure(builder);
            
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.QuestionsCount);
            builder.Property(x => x.CorrectQuestionsCount);
            builder.Property(x => x.IncorrectQuestionsCount);
            builder.Property(x => x.TimeToFinish);
            builder.Property(x => x.Approved);
        }
    }
}