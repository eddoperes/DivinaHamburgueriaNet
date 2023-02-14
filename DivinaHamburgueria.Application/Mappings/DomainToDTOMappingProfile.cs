using AutoMapper;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Domain.ValueObjects;

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
                CreateMap<MenuItemRecipe, MenuItemRecipeDTO>().ReverseMap();
                CreateMap<Ingredient, IngredientDTO>().ReverseMap();
                CreateMap<MenuItemResale, MenuItemResaleDTO>().ReverseMap();
                CreateMap<Menu, MenuDTO>().ReverseMap();
                CreateMap<MenuMenuItem, MenuMenuItemDTO>().ReverseMap();
                CreateMap<Customer, CustomerDTO>().ReverseMap();
                CreateMap<Address, AddressDTO>().ReverseMap();
                CreateMap<Phone, PhoneDTO>().ReverseMap();
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<User, UserNoSecretDTO>().ReverseMap();
                CreateMap<HallOrder, HallOrderDTO>().ReverseMap();
                CreateMap<HallOrderMenuItem, HallOrderMenuItemDTO>().ReverseMap();
                CreateMap<DeliveryOrder, DeliveryOrderDTO>().ReverseMap();
                CreateMap<DeliveryOrderMenuItem, DeliveryOrderMenuItemDTO>().ReverseMap();
                CreateMap<Alarm, AlarmDTO>().ReverseMap();
                CreateMap<QuantityAlarmTriggered, QuantityAlarmTriggeredDTO>().ReverseMap();
                CreateMap<ValidityAlarmTriggered, ValidityAlarmTriggeredDTO>().ReverseMap();
            }
        }
}
