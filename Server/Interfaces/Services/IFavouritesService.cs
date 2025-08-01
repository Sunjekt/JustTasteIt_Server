using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface IFavouritesService
    {
        public IEnumerable<Favourite> GetFavourites();
        public Favourite? GetFavouriteById(int id);
        public void Delete(int id);
        public Favourite Add(FavouriteDTO favouriteDto);

        public void Save();
    }
}
