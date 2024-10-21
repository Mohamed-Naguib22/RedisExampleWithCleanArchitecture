using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Update
{
    public sealed record UpdateProductRequest(Guid Id, UpdateProductDto UpdateProductDto) : IRequest<Unit>;
}
