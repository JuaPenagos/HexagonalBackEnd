using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Services
{
    public class AreaLeaderService : IAreaLeaderService
    {
        private readonly IAreaLeaderRepository _areaLeaderRepository;

        private readonly ILog _logger;
        public AreaLeaderService(IAreaLeaderRepository areaLeaderRepository, ILog logger)
        {
            _areaLeaderRepository = areaLeaderRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<AreaLeader> CreateAreaLeaderAsync(AreaLeaderDto areaLeader)
        {
            AreaLeader areaLeaderEntity = new AreaLeader
            {
                IdArea = areaLeader.IdArea,
                IdLeaderArea = areaLeader.IdLeader
            };
            return await _areaLeaderRepository.CreateAreaLeaderAsync(areaLeaderEntity);
        }


        public async Task<List<AreaLeader>> GetAllAreaLeaderAsync()
        {
            return await _areaLeaderRepository.GetAllAreaLeaderAsync();
        }
    }
}
