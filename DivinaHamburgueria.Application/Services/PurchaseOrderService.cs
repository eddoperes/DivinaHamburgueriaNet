using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DivinaHamburgueria.Domain.Entities.User;

namespace DivinaHamburgueria.Application.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository,
                                    IMapper mapper)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(IPurchaseOrderRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseOrderDTO>> GetAll()
        {
            var purchaseOrder = await _purchaseOrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PurchaseOrderDTO>>(purchaseOrder);
        }

        public async Task<IEnumerable<PurchaseOrderDTO>> GetByProvider(int? providerid)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByProviderAsync(providerid);
            return _mapper.Map<IEnumerable<PurchaseOrderDTO>>(purchaseOrder);
        }

        public async Task<PurchaseOrderDTO?> GetById(int id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            return _mapper.Map<PurchaseOrderDTO>(purchaseOrder);
        }

        public async Task Add(PurchaseOrderDTO purchaseOrderDTO)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDTO);
            purchaseOrder.RegisterState(PurchaseOrder.PurchaseOrderState.Quotation);
            await _purchaseOrderRepository.CreateAsync(purchaseOrder);
        }

        public async Task Update(PurchaseOrderDTO purchaseOrderDTO)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDTO);
            await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        }

        public async Task Remove(int id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder != null)
                await _purchaseOrderRepository.RemoveAsync(purchaseOrder);
        }

        //public async Task<PurchaseOrderDTO?> Patch(int id, PurchaseOrder.PurchaseOrderState state)
        //{
        //    var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
        //    if (purchaseOrder != null)
        //    {
        //        purchaseOrder.RegisterState(state);
        //        await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        //    }
        //    return _mapper.Map<PurchaseOrderDTO>(purchaseOrder);
        //}

        //public async Task<PurchaseOrderDTO?> ChangePayment(int id, PurchaseOrder.PurchaseOrderPayment payment)
        //{
        //    var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
        //    if (purchaseOrder != null)
        //    {
        //        purchaseOrder.RegisterPayment(payment);
        //        await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        //    }
        //    return _mapper.Map<PurchaseOrderDTO>(purchaseOrder);
        //}

        public async Task<PurchaseOrderDTO?> Patch(int id, PurchaseOrderPatchDTO purchaseOrderPatchDTO)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder != null)
            {
                if (purchaseOrder.State < (PurchaseOrder.PurchaseOrderState) purchaseOrderPatchDTO.State)
                {
                    purchaseOrder.RegisterState((PurchaseOrder.PurchaseOrderState) purchaseOrderPatchDTO.State);                    
                }
                if (purchaseOrder.Payment < (PurchaseOrder.PurchaseOrderPayment) purchaseOrderPatchDTO.Payment)
                {
                    purchaseOrder.RegisterPayment((PurchaseOrder.PurchaseOrderPayment) purchaseOrderPatchDTO.Payment);
                }
                await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
            }
            return _mapper.Map<PurchaseOrderDTO>(purchaseOrder);
        }

    }
}
