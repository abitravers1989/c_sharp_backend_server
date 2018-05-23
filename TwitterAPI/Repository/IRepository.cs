using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public interface IRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        //IEnumerable<String> GetAllPosts();
        Task<Post> GetPostByTitle(string title);
        bool SavePost(Post blogPost);

    }
}
