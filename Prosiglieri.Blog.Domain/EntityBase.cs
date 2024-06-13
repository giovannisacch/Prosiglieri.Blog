using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_at { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            Created_At = DateTime.Now;
            Updated_at = DateTime.Now;
        }
    }
}
