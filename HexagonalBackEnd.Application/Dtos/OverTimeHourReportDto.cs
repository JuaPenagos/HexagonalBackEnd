using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Dtos
{
    public class OverTimeHourReportDto
    {

        public DateTime RemunerationDate { get; set; }

        public int RemunerationHours { get; set; }

        public string Justification { get; set; }

        public int IdEmployee { get; set; }

        public int IdRemunerationType { get; set; }

    }
}
