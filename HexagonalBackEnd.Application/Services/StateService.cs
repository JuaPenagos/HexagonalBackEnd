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
    public class StateService :IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<State> CreateStateAsync(State state)
        {
            return await _stateRepository.CreateStateAsync(state);
        }


        public async Task<List<State>> GetAllStateAsync()
        {
            return await _stateRepository.GetAllStateAsync();
        }
    }
}
