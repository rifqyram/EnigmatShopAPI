using EFUpskilling.Entities;
using EnigmatShopAPI.Exceptions;
using EnigmatShopAPI.Repositories;

namespace EnigmatShopAPI.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public async Task<Product> Create(Product payload)
    {
        var product = await _repository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetById(string id)
    {
        try
        {
            var product = await _repository.FindByIdAsync(Guid.Parse(id));
            if (product is null) throw new NotFoundException("product not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetAll()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<Product> Update(Product payload)
    {
        var product = _repository.Update(payload);
        await _persistence.SaveChangesAsync();
        return product;
    }

    public async Task DeleteById(string id)
    {
        var product = await GetById(id);
        _repository.Delete(product);
        await _persistence.SaveChangesAsync();
    }
}