using AutoMapper;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Application.DTOs;

namespace DivinaHamburgueria.Application.Mappings
{
        public class DomainToDTOMappingProfile : Profile
        {
            public DomainToDTOMappingProfile()
            {
                CreateMap<Unidade, UnidadeDTO>().ReverseMap();
                CreateMap<ItemDoEstoqueReceita, ItemDoEstoqueReceitaDTO>().ReverseMap();
                CreateMap<ItemDoEstoqueRevenda, ItemDoEstoqueRevendaDTO>().ReverseMap();
            }
        }
}
