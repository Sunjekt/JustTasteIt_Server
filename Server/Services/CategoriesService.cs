using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class CategoriesService : ICategoriesService
    {

        private ICategoriesRepository categoriesRepository;

        public CategoriesService(ICategoriesRepository _categoriesRepository)
        {
            categoriesRepository = _categoriesRepository;
        }
        public IEnumerable<Category> GetCategories()
        {
            return categoriesRepository.GetCategories();
        }
        public Category? GetCategoryById(int id)
        {
            return categoriesRepository.GetCategoryById(id);
        }
    }
}
