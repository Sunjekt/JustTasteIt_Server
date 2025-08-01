using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategoryById(int id);
    }
}
