using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);

            builder
                .HasMany(x => x.Scores)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("AspNetUsers");
        }
    }
}