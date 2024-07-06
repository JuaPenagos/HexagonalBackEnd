using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Dtos
{
    public class OverTimeHourApproveDto
    {
        public int IdApprrover { get; set; }

        public int IdOvertimeHour { get; set; }

        public int idState { get; set; }

        public string Justificatioon { get; set; }
    }
}
