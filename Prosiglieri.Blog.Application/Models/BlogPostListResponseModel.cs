using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Application.Models
{
    public record BlogPostListResponseModel(List<BlogPostListItemResponseModel> BlogPosts);
    public record BlogPostListItemResponseModel(Guid Id,string Title, int CommentsCount);
}
