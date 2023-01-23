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
    public class HallOrderService : IHallOrderService
    {

        private readonly IHallOrderRepository _hallOrderRepository;
        private readonly IMapper _mapper;

        public HallOrderService(IHallOrderRepository hallOrderRepository,
                                IMapper mapper)
        {
            _hallOrderRepository = hallOrderRepository ?? throw new ArgumentNullException(nameof(IHallOrderRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<HallOrderDTO>> GetAll()
        {
            var hallOrders = await _hallOrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HallOrderDTO>>(hallOrders);
        }

        public async Task<IEnumerable<HallOrderDTO>> GetByCode(int? code)
        {
            var hallOrders = await _hallOrderRepository.GetByCodeAsync(code);
            return _mapper.Map<IEnumerable<HallOrderDTO>>(hallOrders);
        }

        public async Task<HallOrderDTO?> GetById(int id)
        {
            var hallOrder = await _hallOrderRepository.GetByIdAsync(id);
            return _mapper.Map<HallOrderDTO>(hallOrder);
        }

        public async Task Add(HallOrderDTO hallOrderDTO)
        {
            var hallOrder = _mapper.Map<HallOrder>(hallOrderDTO);
            hallOrder.RegisterState(HallOrder.HallOrderState.Issued);
            await _hallOrderRepository.CreateAsync(hallOrder);
        }

        public async Task Update(HallOrderDTO hallOrderDTO)
        {
            var hallOrder = _mapper.Map<HallOrder>(hallOrderDTO);
            await _hallOrderRepository.UpdateAsync(hallOrder);
        }

        public async Task Remove(int id)
        {
            var hallOrder = await _hallOrderRepository.GetByIdAsync(id);
            if (hallOrder != null)
                await _hallOrderRepository.RemoveAsync(hallOrder);
        }

    }
}
