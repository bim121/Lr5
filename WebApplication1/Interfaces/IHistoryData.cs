public interface IHistoryData
{
    Task<List<History>> GetAllAsync();
    Task<History> AddAsync(History model);
    Task<History> UpdateAsync(int id, History model);
    Task<bool> DeleteAsync(int id);
}
