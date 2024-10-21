using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Dtos.Common
{
    public class BaseGetDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
