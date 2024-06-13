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
        public List<Comment> Comments { get; set; }

        public BlogPost(string title, string content)
        {
            Title = title;
            Content = content;
            Comments = new List<Comment>();
        }

        public void AddComment(string comment)
        {
            Comments.Add(new Comment(comment));
        }

        public int GetCommentsCount() 
        {
            if(Comments == null)
                return 0;

            return Comments.Count; 
        }
    }
}
