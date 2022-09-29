using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities;

namespace TSFL.Application.Abstractions
{
    public interface  ICardService
    {
        List<Card> GetAllCard();
    }
}
