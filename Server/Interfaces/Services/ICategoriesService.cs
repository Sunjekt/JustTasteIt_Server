using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface ICategoriesService
    {
        public IEnumerable<Category> GetCategories();
        public Category? GetCategoryById(int id);
    }
}
