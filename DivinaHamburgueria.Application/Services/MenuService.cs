using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _cardapioRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository categoryRepository, IMapper mapper)
        {
            _cardapioRepository = categoryRepository ?? throw new ArgumentNullException(nameof(IMenuRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDTO>> GetAll()
        {
            var categoriesEntity = await _cardapioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuDTO>>(categoriesEntity);
        }

        public async Task<MenuDTO?> GetById(int id)
        {
            var cardapioEntity = await _cardapioRepository.GetByIdAsync(id);
            return _mapper.Map<MenuDTO>(cardapioEntity);
        }

        public async Task Add(MenuDTO CardapioDTO)
        {
            //using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            //    try
            //    {
                    var cardapioEntity = _mapper.Map<Menu>(CardapioDTO);
                    await _cardapioRepository.CreateAsync(cardapioEntity);
            //        scope.Complete();
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
        }

        public async Task Update(MenuDTO CardapioDTO)
        {
            var cardapioEntity = _mapper.Map<Menu>(CardapioDTO);
            await _cardapioRepository.UpdateAsync(cardapioEntity);
        }

        public async Task Remove(int id)
        {
            var cardapioEntity = await _cardapioRepository.GetByIdAsync(id);
            if (cardapioEntity != null)
                await _cardapioRepository.RemoveAsync(cardapioEntity);
        }

    }
}
