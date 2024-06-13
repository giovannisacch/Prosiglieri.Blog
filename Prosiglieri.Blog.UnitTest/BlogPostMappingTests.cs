using Prosiglieri.Blog.Application;
using Prosiglieri.Blog.Application.Models;
using Prosiglieri.Blog.Domain.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.UnitTest
{
    public class BlogPostMappingTests
    {
        [Fact]
        public void BlogPostList_To_BlogPostListResponseModel()
        {
            var blogPostWithComments = new BlogPost("title", "content for this blog");
            blogPostWithComments.AddComment("nice post");
            var blogPostWithoutComments = new BlogPost("title no comments", "content for this blog");

            var blogPosts = new List<BlogPost>()
            {
                blogPostWithComments,
                blogPostWithoutComments
            };

            var listResponseModel = blogPosts.MapToBlogPostListResponseModel();
            var blogListItemWithComments = listResponseModel.BlogPosts.First(x => x.Id == blogPostWithComments.Id);
            var blogListItemWithoutComments = listResponseModel.BlogPosts.First(x => x.Id == blogPostWithoutComments.Id);


            Assert.Equal(blogPostWithComments.Title, blogListItemWithComments.Title);
            Assert.Equal(blogPostWithComments.CommentsCount, blogListItemWithComments.CommentsCount);

            Assert.Equal(blogPostWithoutComments.Title, blogListItemWithoutComments.Title);
            Assert.Equal(blogPostWithoutComments.CommentsCount, blogListItemWithoutComments.CommentsCount);
        }

        [Fact]
        public void EmtpyBlogPostList_To_BlogPostListResponseModel()
        {
            var blogPosts = new List<BlogPost>();
            var listResponseModel = blogPosts.MapToBlogPostListResponseModel();


            Assert.Empty(listResponseModel.BlogPosts);
        }

        [Fact]
        public void BlogPost_To_BlogPostResponseModel()
        {
            var blogPost = new BlogPost("title", "content for this blog");
            blogPost.AddComment("Nice post!");
            var blogPostComment = blogPost.Comments.First();

            var responseModel = blogPost.MapToBlogPostResponseModel();
            var responseModelComment = responseModel.Comments.First();

            Assert.Equal(blogPost.Title, responseModel.Title);
            Assert.Equal(blogPost.Content, responseModel.Content);
            Assert.Equal(blogPostComment.Id, responseModelComment.Id);
            Assert.Equal(blogPostComment.Content, responseModelComment.Content);
        }

        [Fact]
        public void BlogPostWithoutComments_To_BlogPostResponseModel()
        {
            var blogPost = new BlogPost("title", "content for this blog");

            var responseModel = blogPost.MapToBlogPostResponseModel();

            Assert.Equal(blogPost.Title, responseModel.Title);
            Assert.Equal(blogPost.Content, responseModel.Content);
            Assert.Empty(responseModel.Comments);
        }

        [Fact]
        public void CreateBlogPostRequestModel_To_BlogPost()
        {
            var createBlogPost = new CreateBlogPostRequestModel("new post title", "new content");

            var blogPost = createBlogPost.MapToBlogPost();

            Assert.Equal(createBlogPost.Title, blogPost.Title);
            Assert.Equal(createBlogPost.Content, blogPost.Content);
            Assert.Equal(0, blogPost.CommentsCount);
            Assert.Empty(blogPost.Comments);
        }
    }
}
