using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Application.Services;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using log4net;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HexagonalBackEnd.Test.Services
{
    public class OverTimeHourServiceTest
    {
        private Mock<IEmployeeService>  _mockEmployeeService;
        private IOvertimeHoursService _overtimeHoursService;
        private Mock<IOvertimeHoursRepository> _mockOvertimeHoursRepository;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<ILog> _mockLogger;
        public OverTimeHourServiceTest() {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _mockOvertimeHoursRepository = new Mock<IOvertimeHoursRepository>();
            _mockLogger = new Mock<ILog>();
            _overtimeHoursService = new OvertimeHoursService(_mockOvertimeHoursRepository.Object, _mockEmployeeService.Object, _mockLogger.Object);
        }

        [Fact]
        public void CreateOverTimeHoursMaxRemunerationCorrectTest()
        {
            OverTimeHourReportDto overTimeHourReportDto = new OverTimeHourReportDto()
            { 
            IdEmployee =1,
            RemunerationHours = 20,
            RemunerationDate = DateTime.UtcNow,
            IdRemunerationType = 1
            };
            OvertimeHours overtimeHours = new OvertimeHours()
            {
                RemunerationHours = 20,
            };

            OvertimeHours overtimeHoursDB = new OvertimeHours()
            {
                IdEmployee = 1,
                RemunerationHours = 30,
                RemunerationDate = DateTime.UtcNow,
                IdRemunerationType  = 1
               
            };
            List<OvertimeHours> overtimeHoursList = new List<OvertimeHours>() { overtimeHoursDB };
            _mockOvertimeHoursRepository.Setup(x => x.GetAllOverTimeHoursInMonthAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(overtimeHoursList);
            _mockOvertimeHoursRepository.Setup(x => x.CreateOvertimeHoursAsync(It.IsAny<OvertimeHours>())).ReturnsAsync(overtimeHours);

            Assert.Throws<AggregateException>(() => _overtimeHoursService.CreateOvertimeHoursAsync(overTimeHourReportDto).Result);
        }
        }
    }
