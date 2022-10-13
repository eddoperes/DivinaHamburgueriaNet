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
                CreateMap<ItemDoEstoque, ItemDoEstoqueDTO>().ReverseMap();
            }
        }
}
