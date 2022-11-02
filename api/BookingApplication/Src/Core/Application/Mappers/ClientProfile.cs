using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<Client, ClientRequest>().ReverseMap();
        }
    }
}
