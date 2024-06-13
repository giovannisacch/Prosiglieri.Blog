using Microsoft.EntityFrameworkCore;
using Prosiglieri.Blog.Domain.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Infra
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _dbContext;
        private readonly DbSet<BlogPost> _db;

        public BlogPostRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.BlogPosts;
        }

        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(Guid id, bool asNoTracking)
        {
            if (asNoTracking)
                return await _db.Include(x => x.Comments).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return await _db.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(BlogPost blogPost)
        {
            await _db.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(BlogPost blogPost, Comment commentToAdd)
        {
            _dbContext.Comments.Add(commentToAdd);
            _db.Update(blogPost);
            _dbContext.SaveChanges();
        }
    }
}
