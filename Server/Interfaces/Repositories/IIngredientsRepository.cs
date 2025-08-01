using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface IIngredientsRepository
    {
        IEnumerable<Ingredient> GetIngredients();
        Ingredient? GetIngredientById(int id);
        void Delete(int id);
        void Add(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Save();
        bool IngredientExists(int id);
    }
}
