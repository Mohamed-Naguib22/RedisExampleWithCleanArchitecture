using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll
{
    public sealed class GetAllProductsRequest : IRequest<IEnumerable<GetProductDto>>
    {
    }
}
