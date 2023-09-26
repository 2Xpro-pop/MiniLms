using System.Collections.Generic;
using MiniLms.Models;

namespace MiniLms.Services;

public class AccessBlockService : IAccessBlockService
{
    private readonly List<AccessBlock> _accessBlocks = new();
    private readonly IUserService _userService;
    private readonly ICategoryService _categoryService;
    private readonly ILessonsService _lessonsService;

    public AccessBlockService(IUserService userService, ICategoryService categoryService, ILessonsService lessonsService)
    {
        _userService = userService;
        _categoryService = categoryService;
        _lessonsService = lessonsService;
    }

    public Task Block(AccessBlock block)
    {
        _accessBlocks.Add(block);
        return Task.CompletedTask;
    }
    public Task<IEnumerable<AccessBlock>> GetAccessBlockCategoriesForUser(Guid userId)
    {
        var filter = _accessBlocks.Where(ab => ab.UserId == userId)
            .Where(ab => ab.CategoryId != null);

        return Task.FromResult(filter);
    }
    public Task<IEnumerable<AccessBlock>> GetAccessBlockLessonsForUser(Guid userId)
    {
        var filter = _accessBlocks.Where(ab => ab.UserId == userId)
            .Where(ab => ab.LessonId != null);

        return Task.FromResult(filter);
    }
}
