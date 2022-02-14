using AutoMapper;
using LimehouseStudios.Application.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LimehouseStudios.Application.Tests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void Profiles_are_mapped_correctly()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<PostProfile>();
            });

            // Assert
            configuration.AssertConfigurationIsValid();
        }
    }
}
