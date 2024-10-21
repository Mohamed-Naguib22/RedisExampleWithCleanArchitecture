using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProductCommand)
        {
            await _mediator.Send(createProductCommand);

            return Ok();
        }
    }
}
