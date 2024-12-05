public class ProductData : IProductData
{
    private List<Product> _productList;

    public ProductData()
    {
        _productList = new List<Product>
        {
             new Product { Id = 1, Name = "Product 1", Price = 100 },
             new Product { Id = 2, Name = "Product 2", Price = 200 },
             new Product { Id = 3, Name = "Product 3", Price = 150 },
             new Product { Id = 4, Name = "Product 4", Price = 250 },
             new Product { Id = 5, Name = "Product 5", Price = 300 },
             new Product { Id = 6, Name = "Product 6", Price = 120 },
             new Product { Id = 7, Name = "Product 7", Price = 180 },
             new Product { Id = 8, Name = "Product 8", Price = 220 },
             new Product { Id = 9, Name = "Product 9", Price = 270 },
             new Product { Id = 10, Name = "Product 10", Price = 320 },
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
