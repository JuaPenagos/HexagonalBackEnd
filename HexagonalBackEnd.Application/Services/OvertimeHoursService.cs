using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HexagonalBackEnd.Application.Services
{
    public class OvertimeHoursService : IOvertimeHoursService
    {
        private readonly IOvertimeHoursRepository _overtimeHoursRepository;

        private readonly IEmployeeService _employeeService;

        private readonly ILog _logger;
        public OvertimeHoursService(IOvertimeHoursRepository overtimeHoursRepository, IEmployeeService employeeService, ILog logger)
        {
            _overtimeHoursRepository = overtimeHoursRepository;
            _employeeService = employeeService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<OvertimeHours> CreateOvertimeHoursAsync(OverTimeHourReportDto overtimeHours)
        {
            if (overtimeHours.IdRemunerationType == 1)
            {
                await ValidateMaxHours(overtimeHours.RemunerationDate.Month, overtimeHours.RemunerationHours, overtimeHours.IdEmployee);
            }
            return await _overtimeHoursRepository.CreateOvertimeHoursAsync(CreateOvertimeHoursEntity(overtimeHours));
        }

        public async Task<List<OvertimeHours>> GetAllOverTimeHoursAsync()
        {
            return await _overtimeHoursRepository.GetAllOverTimeHoursAsync();
        }

        public async Task ApproveOrRejectOvertimeHoursAsync(OverTimeHourApproveDto overtimeHoursDto)
        {

            await ValidateLeaderRequiredPriorityLeader(overtimeHoursDto.IdApprrover, overtimeHoursDto.IdOvertimeHour);

            OvertimeHours overtimeHours = await  _overtimeHoursRepository.GetOverTimeHourById(overtimeHoursDto.IdOvertimeHour);
            overtimeHours.IdApprover = overtimeHoursDto.IdApprrover;
            overtimeHours.IdState = overtimeHoursDto.idState;
            overtimeHours.JustificationState = overtimeHoursDto.Justificatioon;
            overtimeHours.UpdateDate = DateTime.UtcNow;
            _overtimeHoursRepository.UpdateOvertimeHoursAsync(overtimeHours);
        }

        private async Task ValidateLeaderRequiredPriorityLeader(int idEmployee, int idOvertime)
        {
            var employee = await _employeeService.GetEmployeeRoleByIdAsync(idEmployee);

            var overtime = await _overtimeHoursRepository.GetOverTimeHourById(idOvertime);

            if (employee.Role.Priority != 4 && overtime.IdApprover != null)
            {
                var lastApproverOvertime = await _employeeService.GetEmployeeRoleByIdAsync((int)overtime.IdApprover);
                ValidatePriorityRole(employee, lastApproverOvertime);
            }
        }
        public void ValidatePriorityRole(Employee approver, Employee lastApprover)
        { 

            if (lastApprover.Role.Priority > approver.Role.Priority  )
            {
                _logger.Error("The approver does not have the required priority.");
                throw new ArgumentException("The approver does not have the required priority.");
            }
        }

        private async Task ValidateMaxHours(int month, int remunerationHours, int idEmployee)
        {
            var response =  await _overtimeHoursRepository.GetAllOverTimeHoursInMonthAsync(month, idEmployee);
            if (response.Where(y => y.IdRemunerationType == 1 ).Sum(x => x.RemunerationHours) + remunerationHours > 40)
            {
                _logger.Error("The Employee does not report more than 40 hours.");
                throw new ArgumentException("The Employee does not report more than 40 hours.");
            }
        } 

        private OvertimeHours CreateOvertimeHoursEntity(OverTimeHourReportDto overTimeHourReportDto)
        {
            OvertimeHours overtimeHours = new OvertimeHours()
            {
                IdEmployee = overTimeHourReportDto.IdEmployee,
                RemunerationHours = overTimeHourReportDto.RemunerationHours,
                IdRemunerationType = overTimeHourReportDto.IdRemunerationType,
                RemunerationDate = overTimeHourReportDto.RemunerationDate,
                UpdateDate = DateTime.UtcNow,
                Justification = overTimeHourReportDto.Justification,
                IdState = 1
            };

            return overtimeHours;
        }
    }
}
