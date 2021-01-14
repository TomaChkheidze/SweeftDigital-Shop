using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Models
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string GivenName { get; set; }
        public string AccessToken { get; set; }
    }
}
