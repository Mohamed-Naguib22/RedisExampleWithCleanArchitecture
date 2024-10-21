using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById
{
    public sealed class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var specifications = new GetProductByIdSpecification(request.Id);

            var products = await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(specifications);

            return _mapper.Map<GetProductDto>(products);
        }
    }
}
