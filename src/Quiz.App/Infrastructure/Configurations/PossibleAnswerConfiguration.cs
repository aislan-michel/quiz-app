using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Configurations
{
    public class PossibleAnswerConfiguration : BaseConfiguration<PossibleAnswer>
    {
        public override void Configure(EntityTypeBuilder<PossibleAnswer> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Answer);
            builder.Property(x => x.IsAnswer);

            builder
                .HasOne(x => x.Question)
                .WithMany(x => x.PossibleAnswers)
                .HasForeignKey(x => x.QuestionId);
            
            base.Configure(builder);
        }
    }
}