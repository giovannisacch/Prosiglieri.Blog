using Prosiglieri.Blog.Application.Models;

namespace Prosiglieri.Blog.Application.Services
{
    public interface IBlogPostApplicationService
    {
        Task<BlogPostResponseModel> AddBlogPost(CreateBlogPostRequestModel createBlogPostRequestModel);
        Task<BlogPostResponseModel> AddCommentToPost(CommentRequestModel commentRequestModel);
        Task<BlogPostResponseModel> GetBlogPostByIdAsync(Guid id);
        Task<BlogPostListResponseModel> GetBlogPostsListAsync();
    }
}