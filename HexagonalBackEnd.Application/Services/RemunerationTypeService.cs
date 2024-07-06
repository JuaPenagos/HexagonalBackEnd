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
    public class RemunerationTypeService : IRemunerationTypeService
    {
        private readonly IRemunerationTypeRepository _remunerationTypeRepository;
        public RemunerationTypeService(IRemunerationTypeRepository remunerationTypeRepository)
        {
            _remunerationTypeRepository = remunerationTypeRepository;
        }
        public async Task<RemunerationType> CreateRemunerationTypeAsync(RemunerationType remunerationType)
        {
            return await _remunerationTypeRepository.CreateRemunerationTypeAsync(remunerationType);
        }


        public async Task<List<RemunerationType>> GetAllRemunerationTypeAsync()
        {
            return await _remunerationTypeRepository.GetAllRemunerationTypeAsync();
        }
    }
}
