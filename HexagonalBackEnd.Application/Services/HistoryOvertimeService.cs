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
    public class HistoryOvertimeService :IHistoryOvertimeService
    {
        private readonly IHistoryOvertimeRepository _historyOvertimeRepository;
        public HistoryOvertimeService(IHistoryOvertimeRepository historyOvertimeRepository)
        {
            _historyOvertimeRepository = historyOvertimeRepository;
        }
        public async Task<HistoryOvertime> CreateHistoryOvertimeAsync(HistoryOvertime historyOvertime)
        {
            return await _historyOvertimeRepository.CreateHistoryOvertimeAsync(historyOvertime);
        }


        public async Task<List<HistoryOvertime>> GetAllAsync()
        {
            return await _historyOvertimeRepository.GetAllAsync();
        }
    }
}
