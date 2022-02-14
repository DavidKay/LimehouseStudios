using AutoMapper;
using LimehouseStudios.Application.Services;
using LimehouseStudios.JsonPlaceholder.Api.Contracts;
using LimehouseStudios.JsonPlaceholder.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LimehouseStudios.Application.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void Searching_for_users_should_return_a_failure_if_an_error_occurs()
        {
            // Arrange
            var failureReason = "Simulating a failure.";
            var failedQueryResponse = new EmptyQueryResponse<IEnumerable<Domain.User>>(failureReason);

            var userSearchService = new Mock<IUserSearchService>();
            userSearchService.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(failedQueryResponse);

            var mapper = new Mock<IMapper>();

            var userService = new UserService(mapper.Object, userSearchService.Object);

            // Act
            var response = userService.Handle(new Contracts.GetAllUsersSummaryQuery(), new System.Threading.CancellationToken()).Result;

            // Assert
            Assert.IsFalse(response.IsSuccess);
            Assert.IsNull(response.Value);
            Assert.AreEqual(failureReason, response.ErrorMessage);
        }
    }
}
