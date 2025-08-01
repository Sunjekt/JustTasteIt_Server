using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class IngredientsService : IIngredientsService
    {

        private IIngredientsRepository ingredientsRepository;

        public IngredientsService(IIngredientsRepository _ingredientsRepository)
        {
            ingredientsRepository = _ingredientsRepository;
        }
        public IEnumerable<Ingredient> GetIngredients()
        {
            return ingredientsRepository.GetIngredients();
        }
        public Ingredient? GetIngredientById(int id)
        {
            return ingredientsRepository.GetIngredientById(id);
        }
        public void Delete(int id)
        {
            ingredientsRepository.Delete(id);
            Save();
        }
        public Ingredient Add(IngredientDTO ingredientDto)
        {
            var ingredient = new Ingredient
            {
                Name = ingredientDto.Name,
                Count = ingredientDto.Count,
                RecipeId = ingredientDto.RecipeId,
                MeasurementId = ingredientDto.MeasurementId,
            };
            ingredientsRepository.Add(ingredient);
            ingredientsRepository.Save();
            return ingredient;
        }
        public bool Update(int id, IngredientDTO ingredientDto, out string errorMessage)
        {
            var ingredient = new Ingredient
            {
                Id = id,
                Name = ingredientDto.Name,
                Count = ingredientDto.Count,
                RecipeId = ingredientDto.RecipeId,
                MeasurementId = ingredientDto.MeasurementId,
            };
            ingredientsRepository.Update(ingredient);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!ingredientsRepository.IngredientExists(id))
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
            ingredientsRepository.Save();
        }

    }
}
