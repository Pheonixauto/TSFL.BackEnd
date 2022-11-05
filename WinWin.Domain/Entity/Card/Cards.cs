using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.BaseEntity;

namespace WinWin.Domain.Entities.Card
{
    public class Cards  : BaseEntities
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string PathContent { get; set; } = string.Empty;
        public string PathImage { get; set; } = string.Empty;
    }
}
