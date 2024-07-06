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
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }
        public async Task<Area> CreateAreaAsync(Area area)
        {
            return await _areaRepository.CreateAreaAsync(area);
        }


        public async Task<List<Area>> GetAreasAsync()
        {
            return await _areaRepository.GetAllAreaAsync();
        }
    }
}
