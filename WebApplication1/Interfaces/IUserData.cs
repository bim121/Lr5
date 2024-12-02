public interface IUserData
{
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(User model);
    Task<User> UpdateAsync(int id, User model);
    Task<bool> DeleteAsync(int id);
}
