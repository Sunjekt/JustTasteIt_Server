using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Intefaces.Services;
using Server.Models;
using Server.Models.DTO;

namespace UnitTests
{
    public class RecipesControllerTests
    {
        private readonly Mock<IRecipesService> _recipesServiceMock;
        private readonly RecipesController _controller;

        public RecipesControllerTests()
        {
            _recipesServiceMock = new Mock<IRecipesService>();
            _controller = new RecipesController(_recipesServiceMock.Object);
        }

        [Fact]
        public async Task GetRecipe_ReturnsOkResult_WithRecipes()
        {
            // Arrange
            var recipes = new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Блины", Description = "Вкусные блины на завтрак", Portion = 1, CategoryId = 1, Time = "30 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" },
                new Recipe { Id = 2, Name = "Запеканка", Description = "Вкусная запеканка на завтрак", Portion = 1, CategoryId = 1, Time = "<10 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" },
            };

            _recipesServiceMock.Setup(service => service.GetRecipes()).Returns(recipes);

            // Act
            var result = await _controller.GetRecipe();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnRecipes = Assert.IsAssignableFrom<IEnumerable<Recipe>>(okResult.Value);
            Assert.Equal(2, returnRecipes.Count());
        }

        [Fact]
        public async Task GetRecipeById_ReturnsOkResult_WithRecipe()
        {
            // Arrange
            var recipe = new Recipe { Id = 1, Name = "Блины", Description = "Вкусные блины на завтрак", Portion = 1, CategoryId = 1, Time = "30 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" };
            _recipesServiceMock.Setup(service => service.GetRecipeById(1)).Returns(recipe);

            // Act
            var result = await _controller.GetRecipe(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnRecipe = Assert.IsType<Recipe>(okResult.Value);
            Assert.Equal(recipe.Id, returnRecipe.Id);
            Assert.Equal(recipe.Name, returnRecipe.Name);
        }

        [Fact]
        public async Task GetRecipeById_ReturnsNotFound_WhenRecipeDoesNotExist()
        {
            // Arrange
            _recipesServiceMock.Setup(service => service.GetRecipeById(It.IsAny<int>())).Returns((Recipe)null);

            // Act
            var result = await _controller.GetRecipe(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutRecipe_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var recipeDto = new RecipeDTO { Id = 1, Name = "Блины", Description = "Вкусные блины на завтрак", Portion = 1, CategoryId = 1, Time = "30 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" };
            _recipesServiceMock.Setup(service => service.Update(1, recipeDto, out It.Ref<string>.IsAny)).Returns(true);

            // Act
            var result = await _controller.PutRecipe(1, recipeDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutRecipe_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var recipeDto = new RecipeDTO { Id = 2, Name = "Запеканка", Description = "Вкусная запеканка на завтрак", Portion = 1, CategoryId = 1, Time = "<10 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" };

            // Act
            var result = await _controller.PutRecipe(1, recipeDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostRecipe_ReturnsCreatedAtAction_WhenRecipeIsCreated()
        {
            // Arrange
            var recipeDto = new RecipeDTO { Name = "Блины", Description = "Вкусные блины на завтрак", Portion = 1, CategoryId = 1, Time = "30 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" };
            var recipe = new Recipe { Id = 1, Name = "Запеканка", Description = "Вкусная запеканка на завтрак", Portion = 1, CategoryId = 1, Time = "<10 мин", UserId = "015bf47f-44bb-43fc-bc70-b79a25f546fc", ImagePath = "34jjhk35b53" };
            _recipesServiceMock.Setup(service => service.Add(recipeDto)).Returns(recipe);

            // Act
            var result = await _controller.PostRecipe(recipeDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetRecipe", createdResult.ActionName);
            Assert.Equal(recipe.Id, createdResult.RouteValues["id"]);
        }

        [Fact]
        public async Task DeleteRecipe_ReturnsNoContent_WhenRecipeIsDeleted()
        {
            // Arrange
            _recipesServiceMock.Setup(service => service.Delete(1));

            // Act
            var result = await _controller.DeleteRecipe(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
