using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Domain.Entities
{
    public class Area : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AreaLeader> AreaLeaders { get; set; }
    }
}
