public class HistoryData : IHistoryData
{
    private List<History> _historyList;

    public HistoryData()
    {
        _historyList = new List<History>
        {
            new History { Id = 1, Description = "Event 1", Date = DateTime.Now },
            new History { Id = 2, Description = "Event 2", Date = DateTime.Now },
            new History { Id = 3, Description = "Event 3", Date = DateTime.Now.AddDays(-1) },
            new History { Id = 4, Description = "Event 4", Date = DateTime.Now.AddDays(-2) },
            new History { Id = 5, Description = "Event 5", Date = DateTime.Now.AddDays(-3) },
            new History { Id = 6, Description = "Event 6", Date = DateTime.Now.AddDays(-4) },
            new History { Id = 7, Description = "Event 7", Date = DateTime.Now.AddDays(-5) },
            new History { Id = 8, Description = "Event 8", Date = DateTime.Now.AddDays(-6) },
            new History { Id = 9, Description = "Event 9", Date = DateTime.Now.AddDays(-7) },
            new History { Id = 10, Description = "Event 10", Date = DateTime.Now.AddDays(-8) },
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
