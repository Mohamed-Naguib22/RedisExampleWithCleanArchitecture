using FluentValidation;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Update
{
    public sealed class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.UpdateProductDto.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}
