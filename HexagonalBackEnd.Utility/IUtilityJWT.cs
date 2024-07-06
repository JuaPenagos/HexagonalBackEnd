using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Utility
{
    public interface IUtilityJWT
    {
        string GenerateJWTToken(Employee model);

        bool ValidarToken(string token);
    }
}
