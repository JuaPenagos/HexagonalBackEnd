using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Interfaces
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(Role role);

        Task<List<Role>> GetAllRoleAsync();
    }
}

