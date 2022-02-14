using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LimehouseStudios.Domain.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Ensure_that_users_posts_cannot_be_overridden_once_set()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            var posts = fixture.Create<IEnumerable<Post>>();

            // Act
            user.AssignPosts(posts);
            user.AssignPosts(posts);
        }
    }
}
