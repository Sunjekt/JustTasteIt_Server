using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class RecipeStepsService : IRecipeStepsService
    {

        private IRecipeStepsRepository recipeStepsRepository;

        public RecipeStepsService(IRecipeStepsRepository _recipeStepsRepository)
        {
            recipeStepsRepository = _recipeStepsRepository;
        }
        public IEnumerable<RecipeStep> GetRecipeSteps()
        {
            return recipeStepsRepository.GetRecipeSteps();
        }
        public RecipeStep? GetRecipeStepById(int id)
        {
            return recipeStepsRepository.GetRecipeStepById(id);
        }
        public void Delete(int id)
        {
            recipeStepsRepository.Delete(id);
            Save();
        }
        public RecipeStep Add(RecipeStepDTO stepDto)
        {
            var step = new RecipeStep
            {
                Number = stepDto.Number,
                Description = stepDto.Description,
                ImagePath = stepDto.ImagePath,
                RecipeId = stepDto.RecipeId,
            };
            recipeStepsRepository.Add(step);
            recipeStepsRepository.Save();
            return step;
        }
        public bool Update(int id, RecipeStepDTO stepDto, out string errorMessage)
        {
            var step = new RecipeStep
            {
                Id = id,
                Number = stepDto.Number,
                Description = stepDto.Description,
                ImagePath = stepDto.ImagePath,
                RecipeId = stepDto.RecipeId,
            };
            recipeStepsRepository.Update(step);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!recipeStepsRepository.RecipeStepExists(id))
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
            recipeStepsRepository.Save();
        }

    }
}
