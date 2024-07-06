using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeeAsync();

        Task<Employee?> CreateEmployeeAsync(Employee employee);

        Task UpdateEmployeeAsync(Employee employee);

        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<Employee?> LoginAsync(String user, String password);
    }
}
