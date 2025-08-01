using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Intefaces.Services;
using Server.Models;
using Server.Models.DTO;

namespace UnitTests
{
    public class IngredientsControllerTests
    {
        private readonly Mock<IIngredientsService> _mockService;
        private readonly IngredientsController _controller;

        public IngredientsControllerTests()
        {
            _mockService = new Mock<IIngredientsService>();
            _controller = new IngredientsController(_mockService.Object);
        }

        [Fact]
        public async Task GetIngredient_ReturnsOkResult_WithListOfIngredients()
        {
            // Arrange
            var ingredients = new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Сахар", Count = 4, MeasurementId = 4, RecipeId = 1 },
            new Ingredient { Id = 2, Name = "Макароны", Count = 500, MeasurementId = 2, RecipeId = 1 }
        };
            _mockService.Setup(service => service.GetIngredients()).Returns(ingredients);

            // Act
            var result = await _controller.GetIngredient();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedIngredients = Assert.IsAssignableFrom<IEnumerable<Ingredient>>(okResult.Value);
            Assert.Equal(2, returnedIngredients.Count());
        }

        [Fact]
        public async Task GetIngredient_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 999;
            _mockService.Setup(service => service.GetIngredientById(invalidId)).Returns((Ingredient)null);

            // Act
            var result = await _controller.GetIngredient(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutIngredient_WithValidData_ReturnsNoContent()
        {
            // Arrange
            var ingredientDto = new IngredientDTO { Id = 1, Name = "Макароны", Count = 500, MeasurementId = 2, RecipeId = 1 };
            _mockService.Setup(service => service.Update(1, ingredientDto, out It.Ref<string>.IsAny)).Returns(true);

            // Act
            var result = await _controller.PutIngredient(1, ingredientDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutIngredient_WithInvalidId_ReturnsBadRequest()
        {
            // Arrange
            var ingredientDto = new IngredientDTO { Id = 2, Name = "Макароны", Count = 500, MeasurementId = 2, RecipeId = 1 };

            // Act
            var result = await _controller.PutIngredient(1, ingredientDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostIngredient_WithValidData_ReturnsCreatedAtAction()
        {
            // Arrange
            var ingredientDto = new IngredientDTO { Name = "Макароны", Count = 500, MeasurementId = 2, RecipeId = 1 };
            var ingredient = new Ingredient { Id = 4, Name = "Сахар", Count = 4, MeasurementId = 4, RecipeId = 1 };
            _mockService.Setup(service => service.Add(ingredientDto)).Returns(ingredient);

            // Act
            var result = await _controller.PostIngredient(ingredientDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetIngredient", createdResult.ActionName);
            Assert.Equal(ingredient.Id, createdResult.RouteValues["id"]);
        }

        [Fact]
        public async Task DeleteIngredient_WithValidId_ReturnsNoContent()
        {
            // Arrange
            int validId = 1;
            _mockService.Setup(service => service.Delete(validId));

            // Act
            var result = await _controller.DeleteIngredient(validId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}