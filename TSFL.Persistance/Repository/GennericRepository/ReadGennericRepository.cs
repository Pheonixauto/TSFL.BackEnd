using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.IGennericRepository;
using TSFL.Domain.Entities.Common;
using TSFL.Persistance.Context;

namespace TSFL.Persistance.Repository.GennericRepository
{
    public class ReadGennericRepository<T> : IReadGennericRepository<T> where T : BaseEntity
    {
        private readonly TSFLDbContext _context;
        public DbSet<T> Table => _context.Set<T>();
        public ReadGennericRepository(TSFLDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        //=> await Table.FindAsync(id);
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id.Equals(id));
            //return await Table.FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
     
    }
}
