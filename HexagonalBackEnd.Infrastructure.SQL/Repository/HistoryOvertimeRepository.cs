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
    public class HistoryOvertimeRepository : BaseRepository<HistoryOvertime>, IHistoryOvertimeRepository
    {
        public HistoryOvertimeRepository(DataContext context) :  base(context)
        {
        }

        public async Task<List<HistoryOvertime>> GetAllAsync()
        {
            var historyOvertimes = await GetAsync();
            return historyOvertimes.ToList();
        }

        public async Task<HistoryOvertime?> CreateHistoryOvertimeAsync(HistoryOvertime historyOvertime)
        {
            var historyOvertimeDB = await AddAsync(historyOvertime);
            return historyOvertimeDB;
        }
    }
}
