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
    public class RemunerationTypeRepository : BaseRepository<RemunerationType>, IRemunerationTypeRepository
    {
        public RemunerationTypeRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<RemunerationType>> GetAllRemunerationTypeAsync()
        {
            var remunerationsTypes = await GetAsync();
            return remunerationsTypes.ToList();
        }

        public async Task<RemunerationType?> CreateRemunerationTypeAsync(RemunerationType role)
        {
            var remunerationTypeDB = await AddAsync(role);
            return remunerationTypeDB;
        }
    }
}
