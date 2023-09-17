using PostService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService.Test.Dummy
{
    public class PostDummyData
    {
        public PostDummyData()
        {

        }

        public IEnumerable<Post> GetAllPost()
        {
            var posts = new List<Post>();
            posts.Add(new Post { Id = "FBFF1432-05BC-4686-A888-90B86A70D07C", Title = "test1", UserName = "test1", CreatedAt = DateTime.Now });
            posts.Add(new Post { Id = "FBFF1432-05BC-4686-A888-90B86A70D07D", Title = "test2", UserName = "test2", CreatedAt = DateTime.Now });
            posts.Add(new Post { Id = "FBFF1432-05BC-4686-A888-90B86A70D07E", Title = "test3", UserName = "test3", CreatedAt = DateTime.Now });
            posts.Add(new Post { Id = "FBFF1432-05BC-4686-A888-90B86A70D07F", Title = "test4", UserName = "test4", CreatedAt = DateTime.Now });
            posts.Add(new Post { Id = "FBFF1432-05BC-4686-A888-90B86A70D07G", Title = "test5", UserName = "test5", CreatedAt = DateTime.Now });
            return posts;
        }
    }
}
