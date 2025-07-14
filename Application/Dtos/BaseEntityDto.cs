using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseEntityDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
