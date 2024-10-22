using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.ICaching;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Domain.Constants;
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
        private readonly IRedisCacheService _redisCacheService;

        public GetAllProductsHandler(IMapper mapper, IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = Enumerable.Empty<Product>();
            var cahcedProducts = await _redisCacheService.GetDataAsync<IEnumerable<Product>>(Constants.PRODUCTS_CACHE_KEY);

            if (cahcedProducts is not null)
            {
                products = cahcedProducts;
            }
            else
            {
                var specifications = new GetAllProductsSpecification();
                products = await _unitOfWork.GetRepository<Product>().FindAsync(specifications);

                await _redisCacheService.SetDataAsync(Constants.PRODUCTS_CACHE_KEY, products);
            }

            return _mapper.Map<IEnumerable<GetProductDto>>(products);
        }
    }
}
