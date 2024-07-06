using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IRemunerationTypeRepository
    {
        Task<List<RemunerationType>> GetAllRemunerationTypeAsync();

        Task<RemunerationType?> CreateRemunerationTypeAsync(RemunerationType employee);
    }
}
