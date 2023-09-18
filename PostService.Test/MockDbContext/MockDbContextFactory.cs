using Microsoft.EntityFrameworkCore;
using PostService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService.Test.MockDbContext
{
    public  class MockDbContextFactory
    {
        public AppDbContext DbContextFactory()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("InMem").Options;

            var context = new AppDbContext(options);

            context.Database.EnsureCreated();
            context.AddRange(
                new Post() { Id= "FBFF1432-05BC-4686-A888-90B86A70D07C", Title = "test1", UserName="test1", CreatedAt= DateTime.Now},
                new Post() { Id= "FBFF1432-05BC-4686-A888-90B86A70D07d", Title = "test2", UserName="test2", CreatedAt= DateTime.Now},
                new Post() { Id= "FBFF1432-05BC-4686-A888-90B86A70D07f", Title = "test3", UserName="test3", CreatedAt= DateTime.Now},
                new Post() { Id= "FBFF1432-05BC-4686-A888-90B86A70D07q", Title = "test4", UserName="test4", CreatedAt= DateTime.Now},
                new Post() { Id= "FBFF1432-05BC-4686-A888-90B86A70D07s", Title = "test5", UserName="test5", CreatedAt= DateTime.Now}
                );
            context.SaveChanges();
            return context;
        }
    }
}
