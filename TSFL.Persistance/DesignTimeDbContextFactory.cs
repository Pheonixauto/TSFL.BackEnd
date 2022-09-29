using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TSFL.Persistance.Context;

namespace TSFL.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TSFLDbContext>
    {
        public TSFLDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<TSFLDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.GetConnectionString);
            return new TSFLDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
