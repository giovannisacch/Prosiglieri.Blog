using Microsoft.AspNetCore.Mvc;
using Prosiglieri.Blog.Application.Models;
using Prosiglieri.Blog.Application.Services;
using Prosiglieri.Blog.Domain.BlogPost;

namespace Prosiglieri.Blog.API.Controllers
{
    [ApiController]
    [Route("posts")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostApplicationService _blogPostApplicationService;

        public BlogPostController(IBlogPostApplicationService blogPostApplicationService)
        {
            _blogPostApplicationService = blogPostApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _blogPostApplicationService.GetBlogPostsListAsync();
            if (posts.BlogPosts.Count == 0)
                return NoContent();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _blogPostApplicationService.GetBlogPostByIdAsync(id);
            if (post == null) return NoContent();
            return Ok(post);

        }
        [HttpPost("")]
        public async Task<IActionResult> Post(CreateBlogPostRequestModel blogPost)
        {
            var blogPostResponse = await _blogPostApplicationService.AddBlogPost(blogPost);
            return Ok(blogPostResponse);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(Guid id, CommentRequestModel comment)
        {
            var blogPostResponse = await _blogPostApplicationService.AddCommentToPost(id, comment);
            if (blogPostResponse == null)
                return BadRequest(new ErrorMessage("Post_Not_Found"));
            return Ok(blogPostResponse);

        }
    }
}
