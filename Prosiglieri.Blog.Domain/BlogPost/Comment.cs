using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain.BlogPost
{
    public class Comment : EntityBase
    {
        public Guid BlogPostId { get; set; }
        public string Content { get; set; }

        public BlogPost BlogPost { get; set; }

        public Comment(Guid blogPostId, string content)
        {
            BlogPostId = blogPostId;
            Content = content;
        }

    }
}
