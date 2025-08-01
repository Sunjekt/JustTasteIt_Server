using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class RecipesRepository : RepositoryBase, IRecipesRepository
    {
        public RecipesRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return db.Recipe.Include(i => i.Category).ToList();
        }
        public Recipe? GetRecipeById(int id)
        {
            var recipe = db.Recipe.FirstOrDefault(p => p.Id == id);
            return recipe;
        }
        public void Delete(int id)
        {
            var recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
        }
        public void Add(Recipe recipe)
        {
            db.Recipe.Add(recipe);
        }
        public void Update(Recipe recipe)
        {
            db.Entry(recipe).State = EntityState.Modified;
        }

        public bool RecipeExists(int id)
        {
            return db.Recipe.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
