using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class DeliveryOrderService : IDeliveryOrderService
    {

        private readonly IDeliveryOrderRepository _deliveryOrderRepository;
        private readonly IMapper _mapper;

        public DeliveryOrderService(IDeliveryOrderRepository deliveryOrderRepository,
                                    IMapper mapper)
        {
            _deliveryOrderRepository = deliveryOrderRepository ?? throw new ArgumentNullException(nameof(IDeliveryOrderRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryOrderDTO>> GetAll()
        {
            var deliveryOrder = await _deliveryOrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryOrderDTO>>(deliveryOrder);
        }

        public async Task<DeliveryOrderDTO?> GetById(int id)
        {
            var deliveryOrder = await _deliveryOrderRepository.GetByIdAsync(id);
            return _mapper.Map<DeliveryOrderDTO>(deliveryOrder);
        }

        public async Task Add(DeliveryOrderDTO deliveryOrderDTO)
        {
            var deliveryOrder = _mapper.Map<DeliveryOrder>(deliveryOrderDTO);
            deliveryOrder.RegisterState(DeliveryOrder.DeliveryOrderState.Issued);
            await _deliveryOrderRepository.CreateAsync(deliveryOrder);
        }

        public async Task Update(DeliveryOrderDTO deliveryOrderDTO)
        {
            var deliveryOrder = _mapper.Map<DeliveryOrder>(deliveryOrderDTO);
            await _deliveryOrderRepository.UpdateAsync(deliveryOrder);
        }

        public async Task Remove(int id)
        {
            var deliveryOrder = await _deliveryOrderRepository.GetByIdAsync(id);
            if (deliveryOrder != null)
                await _deliveryOrderRepository.RemoveAsync(deliveryOrder);
        }

    }
}
