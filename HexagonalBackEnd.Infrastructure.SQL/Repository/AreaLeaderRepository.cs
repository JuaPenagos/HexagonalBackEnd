using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Context;
using HexagonalBackEnd.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public class AreaLeaderRepository : BaseRepository<AreaLeader>, IAreaLeaderRepository
    {
        public AreaLeaderRepository(DataContext context) : base(context)
        {

        }
        public async Task<List<AreaLeader>> GetAllAreaLeaderAsync()
        {
            var areas = await GetAsync();
            return areas.ToList();
        }

        public async Task<AreaLeader?> CreateAreaLeaderAsync(AreaLeader areaLeader)
        {
            var areaDB = await AddAsync(areaLeader);
            return areaDB;
        }
    }
}
