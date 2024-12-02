public class HistoryData : IHistoryData
{
    private List<History> _historyList;

    public HistoryData()
    {
        _historyList = new List<History>
        {
            new History { Id = 1, Description = "Event 1", Date = DateTime.Now },
            new History { Id = 2, Description = "Event 2", Date = DateTime.Now },
        };
    }

    public Task<List<History>> GetAllAsync()
    {
        return Task.FromResult(_historyList);
    }

    public Task<History> AddAsync(History model)
    {
        model.Id = _historyList.Max(x => x.Id) + 1;
        _historyList.Add(model);
        return Task.FromResult(model);
    }

    public Task<History> UpdateAsync(int id, History model)
    {
        var item = _historyList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            item.Description = model.Description;
            item.Date = model.Date;
            return Task.FromResult(item);
        }
        return Task.FromResult<History>(null);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var item = _historyList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            _historyList.Remove(item);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
