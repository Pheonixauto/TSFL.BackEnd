using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWin.Domain.Model.Account
{
    public class JwtModel
    {
        public string? AccessToken { get; set; } 
        public string? RefreshToken { get; set; }
        public string? UserName { get; set; }   
        public string? FullName { get; set; }
    }
}
