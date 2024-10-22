using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Application.Exceptions;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById
{
    public sealed class GetProductByIdHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<GetProductByIdRequest, GetProductDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<GetProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var specifications = new GetProductByIdSpecification(request.Id);

            var product = await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(specifications)
                ?? throw new EntityNotFoundException();

            return _mapper.Map<GetProductDto>(product);
        }
    }
}
