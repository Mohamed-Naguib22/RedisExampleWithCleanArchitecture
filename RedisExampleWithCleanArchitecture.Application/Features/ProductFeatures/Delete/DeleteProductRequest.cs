using MediatR;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Delete
{
    public sealed record DeleteProductRequest(Guid Id) : IRequest<Unit>;
}
