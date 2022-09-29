using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.ICardRepository;
using TSFL.Domain.Entities;
using TSFL.Persistance.Context;
using TSFL.Persistance.Repository.GennericRepository;

namespace TSFL.Persistance.Repository.CardRepository
{
    public class CardReadRepository : ReadGennericRepository<Card>, ICardReadRepository
    {
        public CardReadRepository(TSFLDbContext context) : base(context)
        {
        }
    }
}
