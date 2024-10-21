using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Domain.ProductEntities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
