using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string? Name { get; set; }
        public IList<CardGroupCards> CardGroupCard { get; set; }
    }
}
