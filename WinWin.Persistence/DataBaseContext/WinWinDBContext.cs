using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entities.Card;

namespace WinWin.Persistence.DataBaseContext
{
    public class WinWinDBContext : DbContext
    {
        public WinWinDBContext(DbContextOptions<WinWinDBContext> options): base(options)
        {

        }

       public DbSet<Cards> Cards { get; set; }
    }
}
