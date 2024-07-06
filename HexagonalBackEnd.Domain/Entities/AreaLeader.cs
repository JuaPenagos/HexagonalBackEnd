using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Domain.Entities
{
    public class AreaLeader : BaseEntity
    {
        public int IdArea { get; set; }

        public int IdLeaderArea { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Area Area { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
