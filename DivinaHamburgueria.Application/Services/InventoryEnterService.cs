using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class InventoryEnterService: IInventoryEnterService
    {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public InventoryEnterService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task Execute()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //var categoryEntity = _mapper.Map<Category>(categoryDto);
                    //await _categoryRepository.CreateAsync(categoryEntity);


                    var purchaseOrders = await _purchaseOrderRepository.GetAllAsync();
                    Debug.WriteLine(purchaseOrders);

                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
