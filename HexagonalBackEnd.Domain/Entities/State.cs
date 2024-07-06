using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Domain.Entities
{
    public class State : BaseEntity
    {

        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OvertimeHours> OvertimeHours { get; set; }

        public virtual ICollection<HistoryOvertime> HistoryOvertimeInitialStates { get; set; }

        public virtual ICollection<HistoryOvertime> HistoryOvertimeFinalStates { get; set; }
    }
}
