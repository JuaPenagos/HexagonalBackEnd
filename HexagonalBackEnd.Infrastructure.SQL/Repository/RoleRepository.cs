using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Context;
using HexagonalBackEnd.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            var roles = await GetAsync();
            return roles.ToList();
        }

        public async Task<Role?> CreateRoleAsync(Role role)
        {
            var roleDB = await AddAsync(role);
            return roleDB;
        }

        public async Task<Role> GetARoleByIdAsync(int id)
        {
            var roleDB = await GetByIdAsync(id);

            return roleDB;
        }
    }
}
