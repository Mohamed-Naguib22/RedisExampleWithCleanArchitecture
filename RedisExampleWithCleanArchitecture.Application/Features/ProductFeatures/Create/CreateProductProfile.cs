using AutoMapper;
using RedisExampleWithCleanArchitecture.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create
{
    public sealed class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
