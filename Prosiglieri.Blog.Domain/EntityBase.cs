﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosiglieri.Blog.Domain
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
