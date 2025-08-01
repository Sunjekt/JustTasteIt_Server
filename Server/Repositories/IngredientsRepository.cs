using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class IngredientsRepository : RepositoryBase, IIngredientsRepository
    {
        public IngredientsRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return db.Ingredient.Include(i => i.Measurement).ToList();
        }
        public Ingredient? GetIngredientById(int id)
        {
            var ingredient = db.Ingredient.FirstOrDefault(p => p.Id == id);
            return ingredient;
        }
        public void Delete(int id)
        {
            var ingredient = db.Ingredient.Find(id);
            db.Ingredient.Remove(ingredient);
        }
        public void Add(Ingredient ingredient)
        {
            db.Ingredient.Add(ingredient);
        }
        public void Update(Ingredient ingredient)
        {
            db.Entry(ingredient).State = EntityState.Modified;
        }

        public bool IngredientExists(int id)
        {
            return db.Ingredient.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
