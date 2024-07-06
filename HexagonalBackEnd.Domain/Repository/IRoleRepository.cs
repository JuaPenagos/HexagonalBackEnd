using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoleAsync();

        Task<Role?> CreateRoleAsync(Role employee);

        Task<Role> GetARoleByIdAsync(int id);
    }
}
