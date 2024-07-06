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
    public class OvertimeHoursRepository : BaseRepository<OvertimeHours>, IOvertimeHoursRepository
    {
        public OvertimeHoursRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<OvertimeHours>> GetAllOverTimeHoursAsync()
        {
            var overtimeHours = await GetAsync();
            return overtimeHours.ToList();
        }

        public async Task<OvertimeHours?> CreateOvertimeHoursAsync(OvertimeHours overtimeHours)
        {
            var overtimeHoursDB = await AddAsync(overtimeHours);
            return overtimeHoursDB;
        }

        public async Task<List<OvertimeHours>> GetAllOverTimeHoursInMonthAsync(int month, int idEmployee)
        {
            var overtimeHours = await GetAsync(x => x.RemunerationDate.Month == month && x.IdEmployee == idEmployee);
            return overtimeHours.ToList();
        }

        public async Task<OvertimeHours> GetOverTimeHourById(int id)
        {
            var overtimeHours = await GetByIdAsync(id);
            return overtimeHours;
        }

        public async void UpdateOvertimeHoursAsync(OvertimeHours overtimeHours)
        {
            await UpdateAsync(overtimeHours);
        }
    }
}
