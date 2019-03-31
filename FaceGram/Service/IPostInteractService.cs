using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FaceGram.Service
{
    public interface IPostInteractService
    {
        bool toggleLikeAPost(string userId, string postId);

        int getNumberLikedOfPost(string postId);

        bool addComment(string userId, string text, string postId);

        /// <summary>
        /// save file to Image/PostImage/ location in server 
        /// </summary>
        /// <param name="file">File received from client</param>
        /// <returns>absolute image path</returns>
        string saveFileToServer(HttpPostedFileWrapper file);

        /// <summary>
        /// add new Post
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="postContent"></param>
        /// <param name="imagePath"></param>
        /// <returns>return post id</returns>
        string addPost(string userId, string postContent, string imagePath);
        

    }
}
