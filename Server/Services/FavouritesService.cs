using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class FavouritesService : IFavouritesService
    {

        private IFavouritesRepository favouritesRepository;

        public FavouritesService(IFavouritesRepository _favouritesRepository)
        {
            favouritesRepository = _favouritesRepository;
        }
        public IEnumerable<Favourite> GetFavourites()
        {
            return favouritesRepository.GetFavourites();
        }
        public Favourite? GetFavouriteById(int id)
        {
            return favouritesRepository.GetFavouriteById(id);
        }
        public void Delete(int id)
        {
            favouritesRepository.Delete(id);
            Save();
        }
        public Favourite Add(FavouriteDTO FavouriteDto)
        {
            var favourite = new Favourite
            {
                RecipeId = FavouriteDto.RecipeId,
                UserId = FavouriteDto.UserId,
            };
            favouritesRepository.Add(favourite);
            favouritesRepository.Save();
            return favourite;
        }

        public void Save()
        {
            favouritesRepository.Save();
        }

    }
}
