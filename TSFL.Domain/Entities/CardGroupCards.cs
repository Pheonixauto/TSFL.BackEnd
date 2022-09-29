using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Domain.Entities
{
    public class CardGroupCards : BaseEntity
    {
        public Guid CardGroupCards_CardId { get; set; }
        public Guid CardGroupCards_GroupCardId { get; set; }
    }
}
