using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class CardapioService : ICardapioService
    {

        private ICardapioRepository _cardapioRepository;
        private readonly IMapper _mapper;

        public CardapioService(ICardapioRepository categoryRepository, IMapper mapper)
        {
            _cardapioRepository = categoryRepository ?? throw new ArgumentNullException(nameof(Cardapio));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardapioDTO>> GetAll()
        {
            var categoriesEntity = await _cardapioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CardapioDTO>>(categoriesEntity);
        }

        public async Task<CardapioDTO?> GetById(int id)
        {
            var cardapioEntity = await _cardapioRepository.GetByIdAsync(id);
            return _mapper.Map<CardapioDTO>(cardapioEntity);
        }

        public async Task Add(CardapioDTO CardapioDTO)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var cardapioEntity = _mapper.Map<Cardapio>(CardapioDTO);
                    await _cardapioRepository.CreateAsync(cardapioEntity);
                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task Update(CardapioDTO CardapioDTO)
        {
            var cardapioEntity = _mapper.Map<Cardapio>(CardapioDTO);
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
