using Microsoft.EntityFrameworkCore;
using Prosiglieri.Blog.Domain.BlogPost;

namespace Prosiglieri.Blog.Infra
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().ToTable("blog_post");
            modelBuilder.Entity<Comment>().ToTable("comments");

            modelBuilder.Entity<BlogPost>().HasKey(u => u.Id);
            modelBuilder.Entity<Comment>().HasKey(u => u.Id);

            modelBuilder.Entity<BlogPost>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.BlogPost)
                .HasForeignKey(x => x.BlogPostId);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.BlogPost)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogPostId);
        }
    }
}
