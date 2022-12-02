using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.BaseEntity;

namespace WinWin.Domain.Entity.Token
{
    public class Tokens : BaseEntities
    {
        public Guid UserId { get; set; }
        public string? AccessToken { get; set; }
        public DateTime ExpiredDateAccessToken { get;set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpiredDateRefreshToken { get;set; }
        public DateTime CreatedDateToken { get; set; }
    }
}
