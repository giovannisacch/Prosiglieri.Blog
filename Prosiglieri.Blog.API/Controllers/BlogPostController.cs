using Microsoft.AspNetCore.Mvc;
using Prosiglieri.Blog.Application.Models;

namespace Prosiglieri.Blog.API.Controllers
{
    [ApiController]
    [Route("posts")]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(ILogger<BlogPostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();

        }
        [HttpPost("")]
        public async Task<IActionResult> Post(CreateBlogPostRequestModel blogPost)
        {
            return Ok();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(Guid id, CommentRequestModel comment)
        {
            return Ok();

        }
    }
}
