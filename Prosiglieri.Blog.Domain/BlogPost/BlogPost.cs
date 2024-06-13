using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain.BlogPost
{
    public class BlogPost : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentsCount { get; set; }
        public List<Comment> Comments { get; set; }

        public BlogPost()
        {
            
        }
        public BlogPost(string title, string content)
        {
            Title = title;
            Content = content;
            Comments = new List<Comment>();
        }

        public Comment AddComment(string comment)
        {
            var commentObject = new Comment(Id, comment);
            Comments.Add(commentObject);
            CommentsCount++;
            return commentObject;
        }
    }
}
