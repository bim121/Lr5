public interface IProductData
{
    Task<List<Product>> GetAllAsync();
    Task<Product> AddAsync(Product model);
    Task<Product> UpdateAsync(int id, Product model);
    Task<bool> DeleteAsync(int id);
}