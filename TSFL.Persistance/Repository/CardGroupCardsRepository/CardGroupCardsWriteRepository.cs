using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.IRepository.ICardGroupCardsRepository;
using TSFL.Domain.Entities;
using TSFL.Persistance.Context;
using TSFL.Persistance.Repository.GennericRepository;

namespace TSFL.Persistance.Repository.CardGroupCardsRepository
{
    public class CardGroupCardsWriteRepository : WriteGennericRepository<CardGroupCards>, ICardGroupCardsWriteRepository
    {
        public CardGroupCardsWriteRepository(TSFLDbContext context) : base(context)
        {
        }
    }
}
