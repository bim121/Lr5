public class ProductData : IProductData
{
    private List<Product> _productList;

    public ProductData()
    {
        _productList = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
        };
    }

    public Task<List<Product>> GetAllAsync()
    {
        return Task.FromResult(_productList);
    }

    public Task<Product> AddAsync(Product model)
    {
        model.Id = _productList.Max(x => x.Id) + 1;
        _productList.Add(model);
        return Task.FromResult(model);
    }

    public Task<Product> UpdateAsync(int id, Product model)
    {
        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            item.Name = model.Name;
            item.Price = model.Price;
            return Task.FromResult(item);
        }
        return Task.FromResult<Product>(null);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            _productList.Remove(item);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
