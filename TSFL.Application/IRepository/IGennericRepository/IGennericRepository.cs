using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Application.IRepository.IGennericRepository
{
    public interface  IGennericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
