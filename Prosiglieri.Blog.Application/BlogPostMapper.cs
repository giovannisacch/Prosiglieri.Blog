using Prosiglieri.Blog.Application.Models;
using Prosiglieri.Blog.Domain.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Application
{
    public static class BlogPostMapper
    {
        public static BlogPostListResponseModel MapToBlogPostListResponseModel(this List<BlogPost> blogPosts)
        {
            var blogPostListItems = new List<BlogPostListItemResponseModel>();
            if (blogPosts == null)
                return new BlogPostListResponseModel(blogPostListItems);
            blogPosts.ForEach(blogPost => blogPostListItems.Add(new BlogPostListItemResponseModel(blogPost.Id, blogPost.Title, blogPost.CommentsCount)));
            return new BlogPostListResponseModel(blogPostListItems);
        }

        public static BlogPostResponseModel MapToBlogPostResponseModel(this BlogPost blogPost)
        {
            var blogPostCommentsResponseModelList = new List<BlogPostCommentResponseModel>();
            blogPost.Comments?.ForEach(x => blogPostCommentsResponseModelList.Add(new BlogPostCommentResponseModel(x.Id, x.Content)));

            return new BlogPostResponseModel(blogPost.Title, blogPost.Content, blogPostCommentsResponseModelList);
        }

        public static BlogPost MapToBlogPost(this CreateBlogPostRequestModel createBlogPostRequestModel)
        {
            return new BlogPost(createBlogPostRequestModel.Title, createBlogPostRequestModel.Content);
        }
    }
}
