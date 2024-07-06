using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Domain.Entities
{
    public class HistoryOvertime : BaseEntity
    {

        public DateTime MovementDate { get; set; }

        public int IdOvertimeHours { get; set; }

        public int? IdStateInitial { get; set; }

        public int? IdStateFinal { get; set; }

        public string Comments { get; set; }

        public int IdEmployee { get; set; }

        public int? IdApprover { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Approver { get; set; }

        public virtual State InitialState { get; set; }

        public virtual State FinalState { get; set; }
    }
}
