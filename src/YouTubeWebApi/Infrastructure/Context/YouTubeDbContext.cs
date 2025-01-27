using Microsoft.EntityFrameworkCore;
using YouTubeWebApi.Domain;

namespace YouTubeWebApi.Infrastructure.Context
{
    public class YouTubeDbContext : DbContext
    {
        public YouTubeDbContext(DbContextOptions<YouTubeDbContext> options) : base(options)
        {
        }

        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("in_memory_db");
            optionsBuilder.UseSeeding((context, _) =>
            {
                var user = new UserEntity
                {
                    CreatedAt = DateTime.Now,
                    EmailAddress = "test.guler@gmail.com",
                    FullName = "Test Guler",
                    Password = "123456"
                };
                var video = new VideoEntity
                {
                    CreatedAt = DateTime.Now,
                    Description = "Test Description",
                    ThumbnailUrl = "https://test.com",
                    Title = "Test Title",
                    UserId = user.EmailAddress,
                    VideoUrl = "https://test.com"
                };

                context.Add(user);
                context.Add(video);
                context.SaveChanges();
            });

            base.OnConfiguring(optionsBuilder);
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.EmailAddress);
            modelBuilder.Entity<VideoEntity>().HasKey(v => v.Id);
            modelBuilder.Entity<VideoEntity>().HasOne(v => v.User).WithMany(u => u.Videos).HasForeignKey(v => v.UserId);
        }
    }
}
