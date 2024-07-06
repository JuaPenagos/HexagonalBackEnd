using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Context;
using HexagonalBackEnd.Infrastructure.SQL.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var employees = await GetAsync();
            return employees.ToList();
        }

        public async Task<Employee?> CreateEmployeeAsync(Employee employee)
        {
            var employeeDB = await AddAsync(employee);
            return employeeDB;
        }

        public async Task<Employee?> LoginAsync(String user, String password)
        {
            var employeeDB = await _dbSet.Where(x => x.UserName == user && x.Password == password).FirstOrDefaultAsync();
            return employeeDB;
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            await DeleteAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
             await UpdateAsync(employee);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employeeDB = await _dbSet.Where(x => x.Id == id).Include(x => x.Role).FirstOrDefaultAsync();
            return employeeDB;
        }

    }
}
