using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class RecipeStepsRepository : RepositoryBase, IRecipeStepsRepository
    {
        public RecipeStepsRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<RecipeStep> GetRecipeSteps()
        {
            return db.RecipeStep.ToList();
        }
        public RecipeStep? GetRecipeStepById(int id)
        {
            var step = db.RecipeStep.FirstOrDefault(p => p.Id == id);
            return step;
        }
        public void Delete(int id)
        {
            var step = db.RecipeStep.Find(id);
            db.RecipeStep.Remove(step);
        }
        public void Add(RecipeStep step)
        {
            db.RecipeStep.Add(step);
        }
        public void Update(RecipeStep step)
        {
            db.Entry(step).State = EntityState.Modified;
        }

        public bool RecipeStepExists(int id)
        {
            return db.RecipeStep.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
