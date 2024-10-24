﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Delete;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetById;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Update;

namespace RedisExampleWithCleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsRequest()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductByIdRequest(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            await _mediator.Send(new CreateProductRequest(createProductDto));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            await _mediator.Send(new UpdateProductRequest(id, updateProductDto));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductRequest(id));

            return Ok();
        }
    }
}
