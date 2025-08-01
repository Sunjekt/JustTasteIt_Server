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
    public class RecipeStepsController : ControllerBase //контроллер для шагов рецепта
    {
        private readonly IRecipeStepsService recipeStepsService;

        public RecipeStepsController(IRecipeStepsService _recipeStepsService)
        {
            recipeStepsService = _recipeStepsService;
        }

        // GET: api/RecipeSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeStep>>> GetRecipeStep()  // метод получения всех шагов рецептов
        {
            var step = recipeStepsService.GetRecipeSteps();
            return Ok(step);
        }

        // GET: api/RecipeSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeStep>> GetRecipeStep(int id) // метод получения одного шага рецепта по id
        {
            var step = recipeStepsService.GetRecipeStepById(id);
            if (step == null)
            {
                return NotFound();
            }
            return Ok(step);
        }

        // PUT: api/RecipeSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeStep(int id, RecipeStepDTO stepDto) // метод изменения шага рецепта
        {
            if (id != stepDto.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!recipeStepsService.Update(id, stepDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // POST: api/RecipeSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeStep>> PostRecipeStep(RecipeStepDTO stepDto) // метод создания шага рецепта
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step = recipeStepsService.Add(stepDto);

            return CreatedAtAction("GetRecipeStep", new { id = step.Id }, step);
        }

        // DELETE: api/RecipeSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeStep(int id) // метод удаления шага рецепта
        {
            recipeStepsService.Delete(id);
            return NoContent();
        }
    }
}
