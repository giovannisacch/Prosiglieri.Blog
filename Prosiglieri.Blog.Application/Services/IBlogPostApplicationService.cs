using Prosiglieri.Blog.Application.Models;
using Prosiglieri.Blog.Domain.BlogPost;

namespace Prosiglieri.Blog.Application.Services
{
    public interface IBlogPostApplicationService
    {
        Task<BlogPost> AddBlogPost(CreateBlogPostRequestModel createBlogPostRequestModel);
        Task<BlogPostResponseModel> AddCommentToPost(Guid id, CommentRequestModel commentRequestModel);
        Task<BlogPostResponseModel> GetBlogPostByIdAsync(Guid id);
        Task<BlogPostListResponseModel> GetBlogPostsListAsync();
    }
}