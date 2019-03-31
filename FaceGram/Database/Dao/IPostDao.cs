using FaceGram.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceGram.Database.Dao
{
    public interface IPostDao
    {
        int getNumberPostUser(string uid);

        List<Post> getCurrentUserPost(string uid);
        /// <summary>
        /// Get lastest post of user
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns></returns>
        Post getLatestPostOfUser(string id);

        List<Post> getAllPost();

        bool insert(Post post);

        Post getPostById(string postId);
    }
}
