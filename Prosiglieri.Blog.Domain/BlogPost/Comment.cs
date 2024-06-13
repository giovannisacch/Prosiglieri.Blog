using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain.BlogPost
{
    public class Comment : EntityBase
    {
        public string Content { get; set; }

        public Comment(string content)
        {
            Content = content;
        }

    }
}
