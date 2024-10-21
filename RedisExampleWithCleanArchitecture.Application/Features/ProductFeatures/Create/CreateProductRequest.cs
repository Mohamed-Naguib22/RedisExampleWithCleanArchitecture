using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create
{
    public sealed record CreateProductRequest(string Name, decimal Price) : IRequest<Unit>;
}
