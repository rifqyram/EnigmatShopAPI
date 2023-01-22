using EFUpskilling.Entities;
using EnigmatShopAPI.Dto;

namespace EnigmatShopAPI.Services;

public interface IPurchaseService
{
    Task<TransactionResponse> CreateNewTransaction(Purchase purchase);
}