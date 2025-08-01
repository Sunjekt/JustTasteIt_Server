using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Intefaces.Services;
using Server.Models;

namespace UnitTests
{
    public class CategoriesControllerTests
    {
        private readonly Mock<ICategoriesService> _categoriesServiceMock;
        private readonly CategoriesController _controller;

        public CategoriesControllerTests()
        {
            _categoriesServiceMock = new Mock<ICategoriesService>();
            _controller = new CategoriesController(_categoriesServiceMock.Object);
        }

        [Fact]
        public async Task GetCategory_ReturnsOkResult_WithCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Завтрак" },
                new Category { Id = 2, Name = "Обед" }
            };

            _categoriesServiceMock.Setup(service => service.GetCategories()).Returns(categories);

            // Act
            var result = await _controller.GetCategory();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCategories = Assert.IsAssignableFrom<IEnumerable<Category>>(okResult.Value);
            Assert.Equal(2, returnCategories.Count());
        }

        [Fact]
        public async Task GetCategoryById_ReturnsOkResult_WithCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Завтрак" };
            _categoriesServiceMock.Setup(service => service.GetCategoryById(1)).Returns(category);

            // Act
            var result = await _controller.GetCategory(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCategory = Assert.IsType<Category>(okResult.Value);
            Assert.Equal(category.Id, returnCategory.Id);
            Assert.Equal(category.Name, returnCategory.Name);
        }

        [Fact]
        public async Task GetCategoryById_ReturnsNotFound_WhenCategoryDoesNotExist()
        {
            // Arrange
            _categoriesServiceMock.Setup(service => service.GetCategoryById(It.IsAny<int>())).Returns((Category)null);

            // Act
            var result = await _controller.GetCategory(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
