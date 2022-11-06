using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entities.Card;
using WinWin.Domain.Model;

namespace WinWin.Service.AutoMapperProfiles
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cards, CardDTO>().ReverseMap();
        }
    }
}
