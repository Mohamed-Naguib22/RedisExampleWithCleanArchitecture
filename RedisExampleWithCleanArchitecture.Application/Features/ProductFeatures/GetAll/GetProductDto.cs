using RedisExampleWithCleanArchitecture.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Features.ProductFeatures.GetAll
{
    public class GetProductDto : BaseGetDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
