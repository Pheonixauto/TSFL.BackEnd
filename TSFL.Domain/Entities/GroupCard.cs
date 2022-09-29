using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Domain.Entities
{
    public class GroupCard : BaseEntity
    {
        public ICollection<Member> Members { get; set; }
        public IList<CardGroupCards> CardGroupCards { get; set; }

    }
}
