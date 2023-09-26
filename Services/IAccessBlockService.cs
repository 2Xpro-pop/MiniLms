using MiniLms.Models;

namespace MiniLms.Services;

public interface IAccessBlockService
{
    public Task Block(AccessBlock block);
    public Task<IEnumerable<AccessBlock>> GetAccessBlockCategoriesForUser(Guid userId);
    public Task<IEnumerable<AccessBlock>> GetAccessBlockLessonsForUser(Guid userId);
}
