using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class RecipesService : IRecipesService
    {

        private IRecipesRepository recipesRepository;

        public RecipesService(IRecipesRepository _recipesRepository)
        {
            recipesRepository = _recipesRepository;
        }
        public IEnumerable<Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipes();
        }
        public Recipe? GetRecipeById(int id)
        {
            return recipesRepository.GetRecipeById(id);
        }
        public void Delete(int id)
        {
            recipesRepository.Delete(id);
            Save();
        }
        public Recipe Add(RecipeDTO recipeDto)
        {
            var recipe = new Recipe
            {
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                Portion = recipeDto.Portion,
                Time = recipeDto.Time,
                CategoryId = recipeDto.CategoryId,
                UserId = recipeDto.UserId,
                ImagePath = recipeDto.ImagePath,
            };
            recipesRepository.Add(recipe);
            recipesRepository.Save();
            return recipe;
        }
        public bool Update(int id, RecipeDTO recipeDto, out string errorMessage)
        {
            var recipe = new Recipe
            {
                Id = id,
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                Portion = recipeDto.Portion,
                Time = recipeDto.Time,
                CategoryId = recipeDto.CategoryId,
                UserId = recipeDto.UserId,
                ImagePath = recipeDto.ImagePath,
            };
            recipesRepository.Update(recipe);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!recipesRepository.RecipeExists(id))
                {
                    errorMessage = "There was a problem: " + ae.Message;
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public void Save()
        {
            recipesRepository.Save();
        }

    }
}
