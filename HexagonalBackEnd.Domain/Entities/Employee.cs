using HexagonalBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;


namespace HexagonalBackEnd.Domain.Entities
{
    public class Employee : BaseEntity
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password  { get; set; }

        public int IdRole { get; set; }

        public int? IdLeader { get; set; }

        public int? IdAreaLeader { get; set; }
        public virtual AreaLeader AreaLeader { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<OvertimeHours> OvertimeHoursEmployees { get; set; }

        public virtual ICollection<OvertimeHours> OvertimeHoursLeaders { get; set; }

        public virtual ICollection<HistoryOvertime> HistoryOvertimeEmployees { get; set; }

        public virtual ICollection<HistoryOvertime> HistoryOvertimeApprovers { get; set; }

        public virtual ICollection<AreaLeader> AreaLeaders { get; set; }

       

    }
}
