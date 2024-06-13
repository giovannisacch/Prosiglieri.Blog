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

        public async Task<BlogPostResponseModel> AddBlogPost(CreateBlogPostRequestModel createBlogPostRequestModel)
        {
            var blogPost = createBlogPostRequestModel.MapToBlogPost();

            await _blogPostRepository.AddAsync(blogPost);

            return blogPost.MapToBlogPostResponseModel();
        }

        public async Task<BlogPostResponseModel> AddCommentToPost(CommentRequestModel commentRequestModel)
        {
            var blogPost = await _blogPostRepository.GetBlogPostByIdAsync(commentRequestModel.BlogPostId, false);
            if (blogPost == null)
                return null;
            blogPost.AddComment(commentRequestModel.Content);

            await _blogPostRepository.UpdateAsync(blogPost);

            return blogPost.MapToBlogPostResponseModel();
        }
    }
}
