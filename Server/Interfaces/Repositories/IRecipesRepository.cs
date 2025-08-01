using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface IRecipesRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe? GetRecipeById(int id);
        void Delete(int id);
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void Save();
        bool RecipeExists(int id);
    }
}
