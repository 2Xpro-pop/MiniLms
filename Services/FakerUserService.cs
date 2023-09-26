using MiniLms.Models;

namespace MiniLms.Services;

public class FakerUserService : IUserService
{
    private readonly List<User> _users = new()
    {
        new User { Id = Guid.NewGuid(), Name = "Ishigami Kun", Email = "Ish1gam1@gmail.com" },
        new User { Id = Guid.NewGuid(), Name = "Gospoja Kaguya", Email = "kaguya@gmail.com" },
        new User { Id = Guid.NewGuid(), Name = "Yu Ishigami", Email = "yu.ishigami@gmail.com" },
        new User { Id = Guid.NewGuid(), Name = "Miko Iino", Email = "miko.iino@gmail.com" },
        new User { Id = Guid.NewGuid(), Name = "Shirogane Miyuki", Email = "shirogane@gmail.com" },
        new User { Id = Guid.NewGuid(), Name = "Chika Fujiwara", Email = "chika.fujiwara@gmail.com" }
    };

    public Task AddUser(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task DeleteUser(User user)
    {
        _users.Remove(user);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<User>> GetAllUsers() => Task.FromResult<IEnumerable<User>>(_users);
    public Task<User?> GetUserByEmail(string email) => Task.FromResult(_users.FirstOrDefault(x => x.Email == email));
    public Task<User?> GetUserByUsername(string username) => Task.FromResult(_users.FirstOrDefault(x => x.Name == username));
    public Task UpdateUser(User user)
    {
        var id = _users.FirstOrDefault(x => x.Id == user.Id);

        if (id != null)
        {
            var index = _users.IndexOf(id);
            _users[index] = user;
        }

        return Task.CompletedTask;
    }

    public Task AddUsers(IEnumerable<User> users)
    {
        _users.AddRange(users);
        return Task.CompletedTask;
    }

    public Task<User?> GetUserById(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);

        return Task.FromResult(user);
    }
}
