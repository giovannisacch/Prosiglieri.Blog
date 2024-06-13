using Prosiglieri.Blog.Application.Models;
using Prosiglieri.Blog.Domain.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Application.Services
{
    public class BlogPostApplicationService : IBlogPostApplicationService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostApplicationService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostListResponseModel> GetBlogPostsListAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllBlogPostsAsync();

            return blogPosts.MapToBlogPostListResponseModel();
        }

        public async Task<BlogPostResponseModel> GetBlogPostByIdAsync(Guid id)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id, true);

            return blogPost.MapToBlogPostResponseModel();
        }

        public async Task<BlogPost> AddBlogPost(CreateBlogPostRequestModel createBlogPostRequestModel)
        {
            var blogPost = createBlogPostRequestModel.MapToBlogPost();

            await _blogPostRepository.AddAsync(blogPost);

            return blogPost;
        }

        public async Task<BlogPostResponseModel> AddCommentToPost(Guid id, CommentRequestModel commentRequestModel)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(id, false);
            if (blogPost == null)
                return null;
            var comment = blogPost.AddComment(commentRequestModel.Content);

            await _blogPostRepository.AddCommentAsync(blogPost, comment);

            return blogPost.MapToBlogPostResponseModel();
        }
    }
}
