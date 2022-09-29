using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.Abstractions;
using TSFL.Domain.Entities;

namespace TSFL.Persistance.Concreates
{
    public class CardService : ICardService
    {
        public List<Card> GetAllCard()
        {
           return new List<Card>()
           {
               new Card(){ Id = Guid.NewGuid(), Name = "Love"},
               new Card(){ Id = Guid.NewGuid(), Name = "Life"},
           };
        }
    }
}
