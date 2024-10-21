using AutoMapper;
using RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.Create;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile() 
        {
            CreateMap<Product, GetProductDto>();
        }
    }
}
