using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.IGennericRepository;
using TSFL.Domain.Entities;

namespace TSFL.Application.IRepository.IMemberRepository
{
    public interface IMemberWriteRepository : IWriteGennericRepository<Member>
    {
    }
}
