using RedisExampleWithCleanArchitecture.Application.Specifications.Common;
using RedisExampleWithCleanArchitecture.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll
{
    public sealed class GetAllProductsSpecification : BaseSpecification<Product>
    {
        public GetAllProductsSpecification() : base(p => !p.IsDeleted)
        {
            AddOrderBy(e => e.Price);
        }
    }
}
