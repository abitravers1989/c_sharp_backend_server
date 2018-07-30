using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using TwitterAPI.Models;

namespace TwitterAPI.Database
{
    public interface IRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        //Task<IEnumerable<Post>> SortPostsByDate();
        Task<Post> GetPostByTitle(string title);
        Task AddPostToDatabase(Post blogPost);
        Task<bool> UpdateBlogContent(Post blogPost);
        Task<DeleteResult> RemovePost(string blogPostTitle);
    }
}
