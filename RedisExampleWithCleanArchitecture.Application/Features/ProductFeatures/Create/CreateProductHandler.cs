using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create
{
    public sealed class CreateProductHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductRequest, Unit>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.CreateProductDto);

            await _unitOfWork.GetRepository<Product>().AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
