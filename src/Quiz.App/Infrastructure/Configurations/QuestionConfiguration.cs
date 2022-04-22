using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Configurations
{
    public class QuestionConfiguration : BaseConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Text);

            builder
                .HasMany(x => x.PossibleAnswers)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

            builder.Property(x => x.Index);
            
            base.Configure(builder);
        }
    }
}