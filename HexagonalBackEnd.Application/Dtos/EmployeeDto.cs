using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int IdRole { get; set; }

        public int? IdLeader { get; set; }

        public int? IdArea { get; set; }

        public EmployeeDto(string name, string lastName, string userName, string password, int idRole, int? idLeader, int? idArea)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = validatePassword(password);
            IdRole = idRole;
            IdLeader = idLeader;
            IdArea = idArea;
        }
        private string validatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                throw new ArgumentException("Password must contain at least one lowercase letter.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                throw new ArgumentException("Password must contain at least one digit.");
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};:\\|,.<>\/?~]"))
            {
                throw new ArgumentException("Password must contain at least one special character.");
            }
            return password;

        }
    }

    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public int IdRole { get; set; }

        public int? IdLeader { get; set; }
    }
    }
