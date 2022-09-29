using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.IGroupCardRepository;
using TSFL.Domain.Entities;
using TSFL.Persistance.Context;
using TSFL.Persistance.Repository.GennericRepository;

namespace TSFL.Persistance.Repository.GroupCardRepository
{
    public class GroupCardWriteRepository : WriteGennericRepository<GroupCard>, IGroupCardWriteRepository
    {
        public GroupCardWriteRepository(TSFLDbContext context) : base(context)
        {
        }
    }
}
