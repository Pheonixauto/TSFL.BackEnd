using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WinWin.Api.Data
{
    public class WinWinContext : IdentityDbContext<WinwinUser>
    {
        public WinWinContext(DbContextOptions<WinWinContext> options):base (options)
        {

        }
        #region Dbset
        public DbSet<Card>? Cards { get; set; }
        #endregion
    }
}
