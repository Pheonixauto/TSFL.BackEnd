using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entities.Card;

namespace WinWin.Domain.Model
{
    public class CardDTO : Cards
    {
        public string PathImage {  get; set; } = string.Empty;
    }
}
