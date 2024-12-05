public class UserData : IUserData
{
    private List<User> _userList;

    public UserData()
    {
        _userList = new List<User>
        {
            new User { Id = 1, Name = "John", Age = 30 },
            new User { Id = 2, Name = "Alice", Age = 25 },
            new User { Id = 3, Name = "Bob", Age = 35 },
            new User { Id = 4, Name = "Emily", Age = 28 },
            new User { Id = 5, Name = "Michael", Age = 40 },
            new User { Id = 6, Name = "Sophia", Age = 22 },
            new User { Id = 7, Name = "David", Age = 31 },
            new User { Id = 8, Name = "Olivia", Age = 26 },
            new User { Id = 9, Name = "James", Age = 33 },
            new User { Id = 10, Name = "Emma", Age = 29 },
        };
    }

    public Task<List<User>> GetAllAsync()
    {
        return Task.FromResult(_userList);
    }

    public Task<User> AddAsync(User model)
    {
        model.Id = _userList.Max(x => x.Id) + 1;
        _userList.Add(model);
        return Task.FromResult(model);
    }

    public Task<User> UpdateAsync(int id, User model)
    {
        var item = _userList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            item.Name = model.Name;
            item.Age = model.Age;
            return Task.FromResult(item);
        }
        return Task.FromResult<User>(null);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var item = _userList.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            _userList.Remove(item);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
