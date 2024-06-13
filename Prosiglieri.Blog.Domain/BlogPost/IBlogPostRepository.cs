using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain.BlogPost
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost> GetBlogPostByIdAsync(Guid id, bool asNoTracking);
        Task AddAsync(BlogPost blogPost);
        Task AddCommentAsync(BlogPost blogPost, Comment commentToAdd);
    }
}
