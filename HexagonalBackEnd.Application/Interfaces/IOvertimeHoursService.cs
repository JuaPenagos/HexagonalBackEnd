using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Interfaces
{
    public interface IOvertimeHoursService
    {
        Task<OvertimeHours> CreateOvertimeHoursAsync(OverTimeHourReportDto overtimeHours);

        Task<List<OvertimeHours>> GetAllOverTimeHoursAsync();

        Task ApproveOrRejectOvertimeHoursAsync(OverTimeHourApproveDto overtimeHoursDto);
    }
}
