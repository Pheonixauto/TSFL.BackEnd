using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Domain.Entities
{
    public class Member : BaseEntity
    {
        public Guid GroupCard_Id { get; set; }
        public GroupCard GroupCard { get; set; }
    }
}
