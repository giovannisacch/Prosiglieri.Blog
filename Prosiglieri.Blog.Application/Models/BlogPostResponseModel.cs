using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Application.Models
{
    public record BlogPostResponseModel(string Title, string Content, List<BlogPostCommentResponseModel> Comments);
    public record BlogPostCommentResponseModel(Guid Id, string Content);
}
