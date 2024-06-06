using Microsoft.EntityFrameworkCore;
using OpenAI_UIR.Models;

namespace OpenAI_UIR.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Question>()
       
                .HasOne(q => q.Conversation)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.ConversationId)
                .IsRequired();

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithOne(q => q.Answer)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .IsRequired();

            modelBuilder.Entity<Admin>().HasData(
                    new Admin()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jobintech",
                        UserName = "jobintech@jobintech-uir.ma",
                        Password = "@Jobintech2024@",
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
