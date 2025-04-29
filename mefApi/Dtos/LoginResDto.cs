using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class LoginResDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}