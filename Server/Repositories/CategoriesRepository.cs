using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class CategoriesRepository : RepositoryBase, ICategoriesRepository
    {
        public CategoriesRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Category.ToList();
        }
        public Category? GetCategoryById(int id)
        {
            var category = db.Category.FirstOrDefault(p => p.Id == id);
            return category;
        }
    }
}
