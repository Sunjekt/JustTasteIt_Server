using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface IRecipeStepsRepository
    {
        IEnumerable<RecipeStep> GetRecipeSteps();
        RecipeStep? GetRecipeStepById(int id);
        void Delete(int id);
        void Add(RecipeStep step);
        void Update(RecipeStep step);
        void Save();
        bool RecipeStepExists(int id);
    }
}
