using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Models.DTO;
using Server.Intefaces.Services;
using Server.Servieces;

namespace Server.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class FavouritesController : ControllerBase //контроллер для избранных рецептов
    {
        private readonly IFavouritesService favouritesService;

        public FavouritesController(IFavouritesService _favouritesService)
        {
            favouritesService = _favouritesService;
        }

        // GET: api/Favourites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavourite()  // метод получения всех избранных рецептов
        {
            var favourites = favouritesService.GetFavourites();
            return Ok(favourites);
        }

        // GET: api/Favourites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favourite>> GetFavourite(int id) // метод получения одного избранного рецепта по id
        {
            var favourite = favouritesService.GetFavouriteById(id);
            if (favourite == null)
            {
                return NotFound();
            }
            return Ok(favourite);
        }

        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(FavouriteDTO favouriteDto) // метод создания избранного рецепта
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favourite = favouritesService.Add(favouriteDto);

            return CreatedAtAction("GetFavourite", new { id = favourite.Id }, favourite);
        }

        // DELETE: api/Favourites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(int id) // метод удаления избранного рецепта
        {
            favouritesService.Delete(id);
            return NoContent();
        }
    }
}
