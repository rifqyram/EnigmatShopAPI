using EFUpskilling.Entities;
using EnigmatShopAPI.Dto;
using EnigmatShopAPI.Repositories;

namespace EnigmatShopAPI.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _repository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> repository, IPersistence persistence, IProductService productService)
    {
        _repository = repository;
        _persistence = persistence;
        _productService = productService;
    }

    public async Task<TransactionResponse> CreateNewTransaction(Purchase payload)
    {
        await _persistence.BeginTransactionAsync();
        try
        {
            payload.TransDate = DateTime.Now;
            var purchase = await _repository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();

            foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                var product = await _productService.GetById(purchaseDetail.ProductId.ToString());
                product.Stock -= purchaseDetail.Qty;
            }
            await _persistence.SaveChangesAsync();

            await _persistence.CommitTransactionAsync();

            /*
             * foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                purchaseDetailResponses.Add(new PurchaseDetailResponse
                {
                    ProductId = purchaseDetail.ProductId.ToString(),
                    Qty = purchaseDetail.Qty
                });
            }
             */
            
            var purchaseDetailResponses = 
                purchase.PurchaseDetails.Select(purchaseDetail => new PurchaseDetailResponse
                {
                    ProductId = purchaseDetail.ProductId.ToString(), 
                    Qty = purchaseDetail.Qty
                }).ToList();

            TransactionResponse response = new()
            {
                CustomerId = purchase.CustomerId.ToString(),
                TransDate = purchase.TransDate,
                PurchaseDetail = purchaseDetailResponses
            };
            
            return response;
        }
        catch (Exception e)
        {
            await _persistence.RollbackTransactionAsync();
            throw;
        }
    }
}