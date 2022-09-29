using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities;
using TSFL.Domain.Entities.Common;

namespace TSFL.Persistance.Context
{
    public class TSFLDbContext : DbContext
    {
        public TSFLDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<GroupCard>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Member>()
                .HasKey(s => s.Id);

            // one to many (member and group)
            modelBuilder.Entity<Member>()
                .HasOne<GroupCard>(s => s.GroupCard)
                .WithMany(r => r.Members)
                .HasForeignKey(fk => fk.GroupCard_Id);

            //many to many (card and group)
            modelBuilder.Entity<CardGroupCards>()
                .HasKey(grk => new { grk.CardGroupCards_CardId, grk.CardGroupCards_GroupCardId });
        }

        DbSet<Card> Cards { get; set; }
        DbSet<CardGroupCards> CardGroupCards { get; set; }
        DbSet<GroupCard> GroupCards { get; set; }
        DbSet<Member> Members { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
