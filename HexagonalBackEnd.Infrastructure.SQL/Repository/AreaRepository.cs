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
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(DataContext context) : base(context)
        {

        }
        public async Task<List<Area>> GetAllAreaAsync()
        {
            var areas = await GetAsync();
            return areas.ToList();
        }

        public async Task<Area?> CreateAreaAsync(Area area)
        {
            var areaDB = await AddAsync(area);
            return areaDB;
        }
    }
}
