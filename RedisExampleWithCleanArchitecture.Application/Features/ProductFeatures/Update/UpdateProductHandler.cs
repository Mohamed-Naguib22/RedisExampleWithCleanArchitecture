using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Exceptions;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById;
using RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Update
{
    public sealed class UpdateProductHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductRequest, Unit>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var specifications = new GetProductByIdSpecification(request.Id);

            var product = await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(specifications)
                ?? throw new EntityNotFoundException();

            _mapper.Map(request.UpdateProductDto, product);

            _unitOfWork.GetRepository<Product>().Update(product);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
