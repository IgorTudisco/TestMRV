using AutoMapper;
using TestMRV.Data.Dtos;
using TestMRV.Models;

namespace TestMRV.Profiles
{
    public class CardProfiles : Profile
    {
        public CardProfiles()
        {
            CreateMap<CreateCardDTO, Card>();   
            CreateMap<UpdateCardDTO, Card>();
            CreateMap<Card, UpdateCardDTO>();
            CreateMap<Card, ReadCardDTO>();
        }
    }
}
