using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models;

namespace Quiz.App.Infrastructure.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name);
            builder.Property(x => x.LastName);
            builder.Property(x => x.Password);
            builder.Property(x => x.Login);

            builder
                .HasMany(x => x.Scores)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}