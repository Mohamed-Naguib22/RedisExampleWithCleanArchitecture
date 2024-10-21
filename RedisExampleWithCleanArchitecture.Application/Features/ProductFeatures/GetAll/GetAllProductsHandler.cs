using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll
{
    public sealed class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductsHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var specifications = new GetAllProductsSpecification();

            var products = await _unitOfWork.GetRepository<Product>().FindAsync(specifications);

            return _mapper.Map<IEnumerable<GetProductDto>>(products);
        }
    }
}
