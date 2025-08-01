using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class FavouritesRepository : RepositoryBase, IFavouritesRepository
    {
        public FavouritesRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<Favourite> GetFavourites()
        {
            return db.Favourite.Include(i => i.Recipe.Category).ToList();
        }
        public Favourite? GetFavouriteById(int id)
        {
            var favourite = db.Favourite.FirstOrDefault(p => p.Id == id);
            return favourite;
        }
        public void Delete(int id)
        {
            var favourite = db.Favourite.Find(id);
            db.Favourite.Remove(favourite);
        }
        public void Add(Favourite favourite)
        {
            db.Favourite.Add(favourite);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
