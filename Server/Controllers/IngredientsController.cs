using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Intefaces.Services;
using Server.Models;
using Server.Models.DTO;
using Server.Servieces;
using System.Diagnostics.Metrics;

namespace Server.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class IngredientsController : ControllerBase // контроллер для ингредиентов
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService _ingredientsService)
        {
            ingredientsService = _ingredientsService;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredient()  // метод получения всех ингредиентов
        {
            var ingredients = ingredientsService.GetIngredients();
            return Ok(ingredients);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id) // метод получения одного ингредиента по id
        {
            var ingredient = ingredientsService.GetIngredientById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, IngredientDTO ingredientDto) // метод изменения ингредиента
        {
            if (id != ingredientDto.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!ingredientsService.Update(id, ingredientDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostIngredient(IngredientDTO ingredientDto) // метод создания ингредиента
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredient = ingredientsService.Add(ingredientDto);

            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id) // метод удаления ингредиента
        {
            ingredientsService.Delete(id);
            return NoContent();
        }
    }
}
