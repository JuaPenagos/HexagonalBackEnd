using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Domain.Entities
{
    public class OvertimeHours : BaseEntity
    {

        public DateTime RemunerationDate { get; set; }

        public int RemunerationHours { get; set; }

        public string Justification { get; set; }

        public string? JustificationState { get; set; }

        public int IdEmployee { get; set; }

        public int IdState { get; set; }

        public int IdRemunerationType { get; set; }

        public int? IdApprover { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual State State { get; set; }

        public virtual RemunerationType RemunerationType { get; set; }

        public virtual Employee Aproveer { get; set; }

    }
}
