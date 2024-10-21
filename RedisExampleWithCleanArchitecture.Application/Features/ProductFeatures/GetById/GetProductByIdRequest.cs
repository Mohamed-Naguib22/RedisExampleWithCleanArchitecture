using MediatR;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById
{
    public sealed record GetProductByIdRequest(Guid Id) : IRequest<GetProductDto>;
}
