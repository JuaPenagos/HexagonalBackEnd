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
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<State>> GetAllStateAsync()
        {
            var states = await GetAsync();
            return states.ToList();
        }

        public async Task<State?> CreateStateAsync(State state)
        {
            var stateDB = await AddAsync(state);
            return stateDB;
        }
    }
}
