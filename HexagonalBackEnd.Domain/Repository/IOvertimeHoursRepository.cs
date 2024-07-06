using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IOvertimeHoursRepository
    {
        Task<List<OvertimeHours>> GetAllOverTimeHoursAsync();

        Task<OvertimeHours?> CreateOvertimeHoursAsync(OvertimeHours area);

        Task<List<OvertimeHours>> GetAllOverTimeHoursInMonthAsync(int month, int idEmployee);

        Task<OvertimeHours> GetOverTimeHourById(int id);

        void UpdateOvertimeHoursAsync(OvertimeHours overtimeHours);
    }
}
