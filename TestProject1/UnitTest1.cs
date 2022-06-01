using API.Controllers;
using DomainLayer.Model;
using DomainLayer.ViewModel.User;
using Moq;
using RepositoryLayer;
using ServiceLayer.Service.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(GetTestSessions());
            var controller = new CategoryController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());

        }
        private List<Category> GetTestSessions()
        {
            var sessions = new List<Category>();
            sessions.Add(new Category()
            {
              CategoryID = 1,
              CategoryName = "string"
            });
            sessions.Add(new Category()
            {
                CategoryID = 2,
                CategoryName = "string"
            });
            return sessions;
        }
    }
}