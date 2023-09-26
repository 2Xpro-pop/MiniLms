using MiniLms.Models;
using MudBlazor;

namespace MiniLms.Services;

public class FakerCategoryService : ICategoryService
{
    private readonly List<Category> _categories = new()
    {
        new Category { Id = Guid.NewGuid(), Name = "Романтика", Description = "Категория романтических уроков", Icon = Icons.Material.Filled.Favorite, Color = "Primary" },
        new Category { Id = Guid.NewGuid(), Name = "Интриги", Description = "Категория уроков по интригам", Icon = Icons.Material.Filled.Lightbulb, Color = "Secondary" },
        new Category { Id = Guid.NewGuid(), Name = "Юмор", Description = "Категория юмористических уроков", Icon = Icons.Material.Filled.Star, Color = "Success" },
        new Category { Id = Guid.NewGuid(), Name = "Стратегии", Description = "Категория уроков по стратегическим играм", Icon = Icons.Material.Filled.Grass, Color = "Info" },
        new Category { Id = Guid.NewGuid(), Name = "Танцы", Description = "Категория уроков по танцам", Icon = Icons.Material.Filled.Outbound, Color = "Warning" }
    };

    public Task AddCategory(Category category)
    {
        _categories.Add(category);
        return Task.CompletedTask;
    }

    public Task DeleteCategory(Category category)
    {
        _categories.Remove(category);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Category>> GetCategories() => Task.FromResult<IEnumerable<Category>>(_categories);
    public Task<Category?> GetCategory(Guid id) => Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
    public Task UpdateCategory(Category category)
    {
        var categoryFounded = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (categoryFounded != null)
        {
            var index = _categories.IndexOf(categoryFounded);
            _categories[index] = category;
        }

        return Task.CompletedTask;
    }
}
