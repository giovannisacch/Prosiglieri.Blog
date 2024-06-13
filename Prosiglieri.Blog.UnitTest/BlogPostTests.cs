using Prosiglieri.Blog.Domain.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.UnitTest
{
    public class BlogPostTests
    {
        [Fact]
        public void CommentCount_StartAsZero()
        {
            var blogPost = new BlogPost("title", "content for this blog");

            Assert.Equal(0, blogPost.CommentsCount);
        }

        [Fact]
        public void AddComment_Increment_CommentCount()
        {
            var blogPost = new BlogPost("title", "content for this blog");
            blogPost.AddComment("Nice post!");

            Assert.Equal(1, blogPost.CommentsCount);

        }
    }
}
