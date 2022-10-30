using AutoMapper;
using WinWin.Api.Data;
using WinWin.Api.Models;

namespace WinWin.Api.Helpers
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            CreateMap<Card, CardModel>().ReverseMap();
        }
    }
}
