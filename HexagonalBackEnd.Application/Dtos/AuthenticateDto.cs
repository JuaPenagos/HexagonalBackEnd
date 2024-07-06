using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Dtos
{
    public class AuthenticateDto
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }
    }
}
