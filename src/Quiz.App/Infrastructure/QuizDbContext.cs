using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Configurations;
using Quiz.App.Models;

namespace Quiz.App.Infrastructure
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
            
        }

        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PossibleAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}