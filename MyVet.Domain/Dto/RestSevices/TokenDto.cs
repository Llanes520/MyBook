using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.RestSevices
{
    public class TokenDto
    {
        public string Token { get; set; }
        public double Expiration { get; set; }
    }
}
