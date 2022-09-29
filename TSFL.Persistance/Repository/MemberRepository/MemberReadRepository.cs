using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.IMemberRepository;
using TSFL.Domain.Entities;
using TSFL.Persistance.Context;
using TSFL.Persistance.Repository.GennericRepository;

namespace TSFL.Persistance.Repository.MemberRepository
{
    public class MemberReadRepository : ReadGennericRepository<Member>, IMemberReadRepository
    {
        public MemberReadRepository(TSFLDbContext context) : base(context)
        {
        }
    }
}
