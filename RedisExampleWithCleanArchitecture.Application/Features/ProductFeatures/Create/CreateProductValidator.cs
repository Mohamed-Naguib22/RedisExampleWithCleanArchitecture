using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
        }
    }
}
