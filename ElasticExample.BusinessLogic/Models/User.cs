using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticExample.BusinessLogic.Models
{
    public record User
    {
        public Guid Id { get; init; }
        public string? Username { get; init; }
    }
}
