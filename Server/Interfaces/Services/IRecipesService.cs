using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface IRecipesService
    {
        public IEnumerable<Recipe> GetRecipes();
        public Recipe? GetRecipeById(int id);
        public void Delete(int id);
        public Recipe Add(RecipeDTO recipeDto);
        public bool Update(int id, RecipeDTO recipeDto, out string errorMessage);

        public void Save();
    }
}
