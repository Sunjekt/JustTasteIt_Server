using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface IIngredientsService
    {
        public IEnumerable<Ingredient> GetIngredients();
        public Ingredient? GetIngredientById(int id);
        public void Delete(int id);
        public Ingredient Add(IngredientDTO ingredientDTO);
        public bool Update(int id, IngredientDTO ingredientDTO, out string errorMessage);

        public void Save();
    }
}
