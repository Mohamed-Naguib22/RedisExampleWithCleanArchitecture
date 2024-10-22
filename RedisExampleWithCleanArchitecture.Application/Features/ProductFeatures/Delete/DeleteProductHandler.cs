using AutoMapper;
using MediatR;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Application.Exceptions;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById;
using RedisExampleWithCleanArchitecture.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Delete
{
    public sealed class DeleteProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var specifications = new GetProductByIdSpecification(request.Id);

            var product = await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(specifications) 
                ?? throw new EntityNotFoundException();

            product.SoftDelete();

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
