using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStateAsync();

        Task<State?> CreateStateAsync(State employee);
    }
}
