using AutoMapper;
using Moq;
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
using Xunit;

namespace RedisExampleWithCleanArchitecture.Tests.Application.Features.GetById.ProductFeatures
{
    public class GetProductByIdHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetProductByIdHandler _handler;
        private readonly Mock<IBaseRepository<Product>> _productRepositoryMock;

        public GetProductByIdHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _productRepositoryMock = new Mock<IBaseRepository<Product>>();

            _unitOfWorkMock.Setup(uow => uow.GetRepository<Product>()).Returns(_productRepositoryMock.Object);

            _handler = new GetProductByIdHandler(_mapperMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnProductDto_WhenProductExists()
        {
            // Arrange
            var productId = new Guid();
            var product = new Product { Id = productId, Name = "Sample Product" };
            var productDto = new GetProductDto { Id = productId, Name = "Sample Product" };

            _productRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<GetProductByIdSpecification>())).ReturnsAsync(product);

            _mapperMock.Setup(mapper => mapper.Map<GetProductDto>(product)).Returns(productDto);

            var request = new GetProductByIdRequest(productId);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("Sample Product", result.Name);
            _productRepositoryMock.Verify(repo => repo.FirstOrDefaultAsync(It.IsAny<GetProductByIdSpecification>()), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<GetProductDto>(product), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowEntityNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = new Guid();

            _productRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<GetProductByIdSpecification>())).ReturnsAsync((Product)null);

            var request = new GetProductByIdRequest(productId);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _handler.Handle(request, CancellationToken.None));

            _productRepositoryMock.Verify(repo => repo.FirstOrDefaultAsync(It.IsAny<GetProductByIdSpecification>()), Times.Once);
        }
    }

}
