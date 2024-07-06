using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Application.Services;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using HexagonalBackEnd.Utility;
using log4net;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Test.Services
{
    public class EmployeeServiceTest
    {
        private IEmployeeService _employeeService;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<ILog> _mockLogger;
        private Mock<IUtilityJWT> _mockUtility;
        public EmployeeServiceTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockLogger = new Mock<ILog>();
            _mockUtility = new Mock<IUtilityJWT>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object, _mockRoleRepository.Object, _mockLogger.Object, _mockUtility.Object);
        }

        [Fact]
        public void CreateEmployeeCorrectTest()
        {

            EmployeeDto employeeDto = new EmployeeDto("Test", "Juan", "juan@hotmail.com", "Holamundo123.", 4, null, null);
            Role role = new Role();
            role.Priority = 4;
            Employee employee = new Employee();
            employee.Name = "Test";


            _mockRoleRepository.Setup(x => x.GetARoleByIdAsync(It.IsAny<int>())).ReturnsAsync(role);
            _mockEmployeeRepository.Setup(x => x.CreateEmployeeAsync(It.IsAny<Employee>())).ReturnsAsync(employee);


            var response = _employeeService.CreateEmployee(employeeDto);

            Assert.Equal(response.Result.Name, employee.Name);
        }

        [Fact]
        public void CreateEmployeeLeaderRequiredCorrectTest()
        {

            EmployeeDto employeeDto = new EmployeeDto("Test", "Juan", "juan@hotmail.com", "Holamundo123.", 4, null, null);
            Role role = new Role();
            role.Priority = 2;
            Employee employee = new Employee();
            employee.Name = "Test";


            _mockRoleRepository.Setup(x => x.GetARoleByIdAsync(It.IsAny<int>())).ReturnsAsync(role);
            _mockEmployeeRepository.Setup(x => x.CreateEmployeeAsync(It.IsAny<Employee>())).ReturnsAsync(employee);


            Assert.Throws<AggregateException>(()  => _employeeService.CreateEmployee(employeeDto).Result);
        }

        [Fact]
        public void UpdateEmployeeCorrectTest()
        {

            EmployeeUpdateDto employeeDto = new EmployeeUpdateDto()
            { 
               Name = "Test",
               LastName = "Juan",
               IdLeader = 4,
               IdRole = 2
            };
            Employee employee = new Employee();
            employee.Name = "Test";
            _mockEmployeeRepository.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);
            
            _mockEmployeeRepository.Setup(x => x.UpdateEmployeeAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);


            var response = _employeeService.UpdateEmployeeAsync(employeeDto);

            Assert.Equal(response, Task.CompletedTask);
        }
    }
}
