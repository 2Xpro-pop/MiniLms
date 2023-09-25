﻿using MiniLms.Models;

namespace MiniLms.Services;

public interface IUserService
{
    public Task AddUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(User user);
    public Task<User?> GetUserById(Guid id);
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> GetUserByUsername(string username);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task AddUsers(IEnumerable<User> users);
}
