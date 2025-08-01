using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface IFavouritesRepository
    {
        IEnumerable<Favourite> GetFavourites();
        Favourite? GetFavouriteById(int id);
        void Delete(int id);
        void Add(Favourite favourite);
        void Save();
    }
}
