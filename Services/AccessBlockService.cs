using MiniLms.Models;

namespace MiniLms.Services;

public class AccessBlockService : IAccessBlockService
{
    private readonly IUserService _userService;
    private readonly ICategoryService _categoryService;
    private readonly ILessonsService _lessonsService;

    public AccessBlockService(IUserService userService, ICategoryService categoryService, ILessonsService lessonsService)
    {
        _userService = userService;
        _categoryService = categoryService;
        _lessonsService = lessonsService;
    }

    public Task<IEnumerable<AccessBlock>> GetAccessBlockCategoriesForUser(Guid userId)
    {
    }
    public Task<IEnumerable<AccessBlock>> GetAccessBlockLessonsForUser(Guid userId) => throw new NotImplementedException();
}
