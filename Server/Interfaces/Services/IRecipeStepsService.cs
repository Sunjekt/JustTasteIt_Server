using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface IRecipeStepsService
    {
        public IEnumerable<RecipeStep> GetRecipeSteps();
        public RecipeStep? GetRecipeStepById(int id);
        public void Delete(int id);
        public RecipeStep Add(RecipeStepDTO stepDto);
        public bool Update(int id, RecipeStepDTO stepDto, out string errorMessage);

        public void Save();
    }
}
