using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Dtos
{
    public class EmployeeUpdateDto
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public int? IdRole { get; set; }

        public int? IdLeader { get; set; }

        public int? IdArea { get; set; }

    }
}
