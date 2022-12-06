using AutoMapper;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Application.DTOs;

namespace DivinaHamburgueria.Application.Mappings
{
        public class DomainToDTOMappingProfile : Profile
        {
            public DomainToDTOMappingProfile()
            {
                CreateMap<Unity, UnityDTO>().ReverseMap();
                CreateMap<InventoryItem, InventoryItemDTO>().ReverseMap();
                CreateMap<Provider, ProviderDTO>().ReverseMap();
                CreateMap<PurchaseOrder, PurchaseOrderDTO>().ReverseMap();
                CreateMap<PurchaseOrderInventoryItem, PurchaseOrderInventoryItemDTO>().ReverseMap();
                CreateMap<Inventory, InventoryDTO>().ReverseMap();
                CreateMap<Eatable, EatableDTO>().ReverseMap();
            }
        }
}
