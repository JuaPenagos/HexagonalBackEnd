using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IHistoryOvertimeRepository
    {
        Task<List<HistoryOvertime>> GetAllAsync();

        Task<HistoryOvertime?> CreateHistoryOvertimeAsync(HistoryOvertime area);
    }
}
