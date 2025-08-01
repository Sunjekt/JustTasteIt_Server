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
    public class RecipesController : ControllerBase //контроллер для рецепта
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService _recipesService)
        {
            recipesService = _recipesService;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipe()  // метод получения всех рецептов
        {
            var recipes = recipesService.GetRecipes();
            return Ok(recipes);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id) // метод получения одного рецепта по id
        {
            var recipe = recipesService.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, RecipeDTO recipeDto) // метод изменения рецепта
        {
            if (id != recipeDto.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!recipesService.Update(id, recipeDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(RecipeDTO recipeDto) // метод создания рецепта
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = recipesService.Add(recipeDto);

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id) // метод удаления рецепта
        {
            recipesService.Delete(id);
            return NoContent();
        }
    }
}
