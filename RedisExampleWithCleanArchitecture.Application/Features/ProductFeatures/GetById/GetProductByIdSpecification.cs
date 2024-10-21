using RedisExampleWithCleanArchitecture.Application.Specifications.Common;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById
{
    public sealed class GetProductByIdSpecification : BaseSpecification<Product>
    {
        public GetProductByIdSpecification(Guid id) : base(p => id == p.Id && !p.IsDeleted)
        {
        }
    }
}
