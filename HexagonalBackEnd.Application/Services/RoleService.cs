using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> CreateRoleAsync(Role role)
        {
            return await _roleRepository.CreateRoleAsync(role);
        }


        public async Task<List<Role>> GetAllRoleAsync()
        {
            return await _roleRepository.GetAllRoleAsync();
        }
    }
}
