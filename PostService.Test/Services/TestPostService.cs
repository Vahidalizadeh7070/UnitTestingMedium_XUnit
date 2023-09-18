using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;
using PostService.API.Models;
using PostService.API.Services;
using PostService.Test.MockDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService.Test.Services
{
    public class TestPostService
    {
        public MockDbContextFactory contextFactory;

        public TestPostService()
        {
            contextFactory = new MockDbContextFactory();
        }

        [Fact]
        public async Task Add_PostService_Success()
        {
            // Arrange
            var post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                Title = "testNew",
                UserName = "testNew",
                CreatedAt = DateTime.Now
            };

            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.AddAsync(post);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task Add_PostService_Failure()
        {

            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.AddAsync(null);

            // Assert
            Assert.Null(res);
        }

        [Fact]
        public async Task Edit_PostService_Success()
        {
            string id = "FBFF1432-05BC-4686-A888-90B86A70D07C";
            // Arrange
            var post = new Post
            {
                Id = id,
                Title = "testNew-update",
                UserName = "testNew-update",
                CreatedAt = DateTime.Now
            };

            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.EditAsync(post);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task Edit_PostService_Failure()
        {
            // Arrange
            var post = new Post();
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.EditAsync(post);

            // Assert
            Assert.Null(res.Id);
        }

        [Fact]
        public async Task Delete_PostService_Success()
        {
            string id = "FBFF1432-05BC-4686-A888-90B86A70D07C";
            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.DeleteAsync(id);

            // Assert
            Assert.True(res);
        }

        [Fact]
        public async Task Delete_PostService_Failure()
        {
            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.DeleteAsync("");

            // Assert
            Assert.False(res);
        }

        [Fact]
        public async Task GetById_PostService_Success()
        {


            string id = "FBFF1432-05BC-4686-A888-90B86A70D07C";
            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetByIdAsync(id);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task GetById_PostService_Failure()
        {
            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetByIdAsync("");

            // Assert
            Assert.Null(res);
        }

        [Fact]
        public async Task GetAll_PostService_Success()
        {
            // Arrange
            var postService = new PostServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetAllAsync();

            // Assert
            Assert.NotNull(res);
        }
    }
}
